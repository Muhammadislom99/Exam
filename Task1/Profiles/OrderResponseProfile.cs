using AutoMapper;
using Task1.Data.Entities;
using Task1.DTOs;

namespace Task1.Profiles;

public class OrderResponseProfile : Profile
{
    public OrderResponseProfile()
    {
        CreateMap<Order, OrderResponse>()
            .ForMember(dest => dest.OrderDate,
                opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(des => des.OrderItems, opt => opt.MapFrom(src => src.Items));
    }
}

public class OrderItemsResponseProfile : Profile
{
    public OrderItemsResponseProfile()
    {
        CreateMap<OrderItem, OrderItemsResponse>();
    }
}