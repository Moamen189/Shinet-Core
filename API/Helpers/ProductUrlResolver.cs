using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration configuration;

        public ProductUrlResolver(IConfiguration Configuration)
        {
            configuration = Configuration;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return configuration["APIURL"] + source.PictureUrl;

            }

            return null;
        }
    }
}
