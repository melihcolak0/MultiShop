using AutoMapper;
using MultiShop.Comment.DTOs.UserCommentDTOs;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserComment, ResultUserCommentDTO>().ReverseMap();
            CreateMap<UserComment, CreateUserCommentDTO>().ReverseMap();
            CreateMap<UserComment, UpdateUserCommentDTO>().ReverseMap();
            CreateMap<UserComment, GetUserCommentDTO>().ReverseMap();
        }
    }
}
