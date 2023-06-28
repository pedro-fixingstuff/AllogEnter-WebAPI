using Univali.Api.Features.Courses.Queries.GetCourseDetail;

namespace Univali.Api.Features.Authors.Queries.GetAuthorWithCoursesDetail;

public class GetAuthorWithCoursesDetailDto
{
    public int AuthorId {get; set;}
    public string FirstName {get; set;} = string.Empty;
   	public string LastName {get; set;} = string.Empty;
    public ICollection<GetCourseDetailDto> Courses {get;set;} = new List<GetCourseDetailDto>();
}