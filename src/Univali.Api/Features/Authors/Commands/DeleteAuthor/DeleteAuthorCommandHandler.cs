using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Authors.Commands.DeleteAuthor;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
{
    private readonly IAuthorRepository _authorRepository;

    public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        _authorRepository.DeleteAuthor(request.AuthorId);
        await _authorRepository.SaveChangesAsync();
    }
}