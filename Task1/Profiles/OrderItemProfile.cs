using AutoMapper;
using Task1.Data.Entities;
using Task1.DTOs;

namespace Task1.Profiles;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<AddItemDto, OrderItem>();
    }
}