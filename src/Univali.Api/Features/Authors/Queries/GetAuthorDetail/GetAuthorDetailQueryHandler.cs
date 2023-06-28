using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Authors.Queries.GetAuthorDetail;

public class GetAuthorDetailQueryHandler : IRequestHandler<GetAuthorDetailQuery, GetAuthorDetailDto>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public GetAuthorDetailQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<GetAuthorDetailDto> Handle(GetAuthorDetailQuery request, CancellationToken cancellationToken)
    {
        var authorFromDatabase = await _authorRepository.GetAuthorByIdAsync(request.AuthorId);
        return _mapper.Map<GetAuthorDetailDto>(authorFromDatabase);
    }
}