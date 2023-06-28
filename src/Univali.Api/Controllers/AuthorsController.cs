using AutoMapper;
using MediatR;
using Univali.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Features.Authors.Commands.CreateAuthor;
using Univali.Api.Features.Authors.Commands.UpdateAuthor;
using Univali.Api.Features.Authors.Commands.DeleteAuthor;
using Univali.Api.Features.Authors.Queries.GetAuthorDetail;
using Univali.Api.Features.Authors.Queries.GetAuthorWithCoursesDetail;
using Microsoft.AspNetCore.Authorization;

namespace Univali.Api.Controllers;

[Route("api/authors")]
[Authorize]
public class AuthorsController : MainController
{
    private readonly IMapper _mapper;
    private readonly IAuthorRepository _authorRepository;
    private readonly IMediator _mediator;

    public AuthorsController(IMapper mapper, IAuthorRepository authorRepository, IMediator mediator)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("{authorId}", Name = "GetAuthorById")]
    public async Task<ActionResult<GetAuthorDetailDto>> GetAuthorById(
        int authorId
    )
    {
        var getAuthorQuery = new GetAuthorDetailQuery {AuthorId = authorId};

        var authorToReturn = await _mediator.Send(getAuthorQuery);

        if (authorToReturn == null) return NotFound();

        return Ok(authorToReturn);
    }

    [HttpGet("with-courses/{authorId}")]
    public async Task<ActionResult<GetAuthorWithCoursesDetailDto>> GetAuthorWithCourses(
        int authorId
    )
    {
        var getAuthorWithCoursesQuery = new GetAuthorWithCoursesDetailQuery {AuthorId = authorId};

        var authorToReturn = await _mediator.Send(getAuthorWithCoursesQuery);

        if (authorToReturn == null) return NotFound();

        return Ok(authorToReturn);
    }

    [HttpPost]
    public async Task<ActionResult<CreateAuthorDto>> CreateAuthor (
        CreateAuthorCommand createAuthorCommand
    )
    {
        var authorToReturn = await _mediator.Send(createAuthorCommand);

        return CreatedAtRoute
        (
            "GetAuthorById",
            new { authorId = authorToReturn.AuthorId },
            authorToReturn
        );
    }

    [HttpPut("{id}")]

    public async Task<ActionResult> UpdateAuthor(
        int id,
        UpdateAuthorCommand updateAuthorCommand
    )
    {
        if(updateAuthorCommand.AuthorId != id) return BadRequest();
        var updateCustomer = await _mediator.Send(updateAuthorCommand);

        if(updateCustomer.Success == false) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuthor(int authorId)
    {
        var authorExists = await _authorRepository.AuthorExistsAsync(authorId);

        if (!authorExists) return NotFound();

        var deleteAuthorCommand = new DeleteAuthorCommand {AuthorId = authorId};

        await _mediator.Send(deleteAuthorCommand);

        return NoContent();
    }
}