
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infastrucure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
     
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository ProductRepository , IGenericRepository<Product> ProductRepo , IGenericRepository<ProductBrand> ProductBrandRepo , IGenericRepository<ProductType> ProductTypeRepo , IMapper mapper )
        {
          
            _productRepository = ProductRepository;
            _productRepo = ProductRepo;
            _productBrandRepo = ProductBrandRepo;
            _productTypeRepo = ProductTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task< ActionResult<List<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
        {
            var spec = new ProductWithTypesAndBrandSpecification(productSpecParams);
            var Products = await _productRepo.GetListWithSpec(spec);
            return Ok(_mapper.Map<IReadOnlyList<ProductToReturnDto>>(Products));
        }


        [HttpGet("id")]

        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            return _mapper.Map<ProductToReturnDto>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductsBrand()
        {
            var ProductBrand = await _productBrandRepo.GetAllAsync();

            return Ok(ProductBrand);
        }

        [HttpGet("types")]
        
        public async Task<ActionResult<List<ProductType>>> GetProductsTypes()
        {
            var ProductTypes = await _productTypeRepo.GetAllAsync();

            return Ok (ProductTypes);
        }
    }
}
