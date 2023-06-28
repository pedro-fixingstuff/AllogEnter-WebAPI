using MediatR;

namespace Univali.Api.Features.Authors.Queries.GetAuthorWithCoursesDetail;

public class GetAuthorWithCoursesDetailQuery : IRequest<GetAuthorWithCoursesDetailDto>
{
    public int AuthorId {get; set;}
}