using AutoMapper;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.DTOs.UserMessageDTOs;

namespace MultiShop.Message.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserMessage, ResultUserMessageDTO>().ReverseMap();
            CreateMap<UserMessage, CreateUserMessageDTO>().ReverseMap();
            CreateMap<UserMessage, UpdateUserMessageDTO>().ReverseMap();
            CreateMap<UserMessage, GetUserMessageDTO>().ReverseMap();
            CreateMap<UserMessage, ResultInboxDTO>().ReverseMap();
            CreateMap<UserMessage, ResultSendboxDTO>().ReverseMap();
        }
    }
}
