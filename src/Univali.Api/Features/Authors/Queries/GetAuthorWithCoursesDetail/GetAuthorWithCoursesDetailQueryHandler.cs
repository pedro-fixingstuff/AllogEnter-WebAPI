using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Authors.Queries.GetAuthorWithCoursesDetail;

public class GetAuthorWithCoursesDetailQueryHandler : IRequestHandler<GetAuthorWithCoursesDetailQuery, GetAuthorWithCoursesDetailDto>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public GetAuthorWithCoursesDetailQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<GetAuthorWithCoursesDetailDto> Handle(GetAuthorWithCoursesDetailQuery request, CancellationToken cancellationToken)
    {
        var authorFromDatabase = await _authorRepository.GetAuthorWithCoursesByIdAsync(request.AuthorId);
        return _mapper.Map<GetAuthorWithCoursesDetailDto>(authorFromDatabase);
    }
}