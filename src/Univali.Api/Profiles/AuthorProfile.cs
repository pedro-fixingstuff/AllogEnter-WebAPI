using AutoMapper;
using Univali.Api.Entities;
using Univali.Api.Features.Authors.Commands.CreateAuthor;
using Univali.Api.Features.Authors.Commands.UpdateAuthor;
using Univali.Api.Features.Authors.Queries.GetAuthorWithCoursesDetail;

namespace Univali.Api.Profiles;

public class AuthorProfile : Profile
{
    public AuthorProfile ()
    {
        CreateMap<Author, GetAuthorWithCoursesDetailDto>();
        CreateMap<CreateAuthorCommand, Author>();
        CreateMap<Author, CreateAuthorDto>();
        CreateMap<UpdateAuthorCommand, Author>();
    }
}