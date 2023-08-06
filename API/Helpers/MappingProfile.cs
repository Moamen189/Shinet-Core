using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Identity;

namespace API.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d=> d.ProductBrand , o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType , x => x.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl ,  x  => x.MapFrom<ProductUrlResolver>());

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>().ReverseMap();
            CreateMap<BasketItemDto, BasketItem>().ReverseMap();

            CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();

            CreateMap<Core.Entities.OrderAggregate.Order, OrderToReturnDto>()
                .ForMember(x => x.DeliveryMethod , o => o.MapFrom(s=> s.DeliveryMethod.ShortName))
                .ForMember(s => s.ShippingPrice , n=> n.MapFrom(l => l.DeliveryMethod.Price));
            CreateMap<Core.Entities.OrderAggregate.OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId , o=>o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))

                ;

        }
    }
}
