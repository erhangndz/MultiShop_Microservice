using AutoMapper;
using Multishop.Order.Application.Features.Mediator.Commands.AddressCommands;
using Multishop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using Multishop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using Multishop.Order.Application.Features.Mediator.Results.AddressResults;
using Multishop.Order.Application.Features.Mediator.Results.OrderDetailResults;
using Multishop.Order.Application.Features.Mediator.Results.OrderingResults;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.MappingConfigs
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateAddressCommand, Address>().ReverseMap();
            CreateMap<UpdateAddressCommand, Address>().ReverseMap();
            CreateMap<GetAddressByIdQueryResult, Address>().ReverseMap();
            CreateMap<GetAddressQueryResult, Address>().ReverseMap();

            CreateMap<CreateOrderDetailCommand, OrderDetail>().ReverseMap();
            CreateMap<UpdateOrderDetailCommand, OrderDetail>().ReverseMap();
            CreateMap<GetOrderDetailByIdQueryResult, OrderDetail>().ReverseMap();
            CreateMap<GetOrderDetailQueryResult, OrderDetail>().ReverseMap();


            CreateMap<CreateOrderingCommand, Ordering>().ReverseMap();
            CreateMap<UpdateOrderingCommand, Ordering>().ReverseMap();
            CreateMap<GetOrderingQueryResult, Ordering>().ReverseMap();
            CreateMap<GetOrderingByIdQueryResult, Ordering>().ReverseMap();

        }
    }
}
