using AutoMapper;
using TakeAway.Comment.DAL.Entities;
using TakeAway.Comment.Dtos;

namespace TakeAway.Comment.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserComment, ResultUserCommentDto>().ReverseMap();
            CreateMap<UserComment, CreateUserCommentDto>().ReverseMap();
            CreateMap<UserComment, UpdateUserCommentDto>().ReverseMap();
            CreateMap<UserComment, GetByIdUserCommentDto>().ReverseMap();
        }
    }
}
