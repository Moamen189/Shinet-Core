using API.Dtos;
using AutoMapper;
using Core.Entities;

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
        }
    }
}
