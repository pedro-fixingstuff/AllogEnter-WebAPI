using AutoMapper;
using Univali.Api.Entities;
using Univali.Api.Features.Courses.Queries.GetCourseDetail;

namespace Univali.Api.Profiles;

public class CourseProfile : Profile
{
    public CourseProfile ()
    {
        CreateMap<Course, GetCourseDetailDto>();
    }
}