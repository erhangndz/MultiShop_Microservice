using AutoMapper;
using Multishop.Message.DataAccess.Entities;
using Multishop.Message.Dtos;

namespace Multishop.Message.Mapping
{
    public class UserMessageMapping: Profile
    {
        public UserMessageMapping()
        {
            CreateMap<CreateMessageDto, UserMessage>().ReverseMap();
            CreateMap<UpdateMessageDto, UserMessage>().ReverseMap();
            CreateMap<ResultMessageDto, UserMessage>().ReverseMap();
        }
    }
}
