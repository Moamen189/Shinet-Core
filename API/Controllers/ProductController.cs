
using Core.Entities;
using Core.Interfaces;
using Infastrucure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
     
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public ProductController(IProductRepository ProductRepository , IGenericRepository<Product> ProductRepo , IGenericRepository<ProductBrand> ProductBrandRepo , IGenericRepository<ProductType> ProductTypeRepo )
        {
          
            _productRepository = ProductRepository;
            _productRepo = ProductRepo;
            _productBrandRepo = ProductBrandRepo;
            _productTypeRepo = ProductTypeRepo;
        }

        [HttpGet]

        public async Task< ActionResult<List<Product>>> GetProducts()
        {
            var Products = await _productRepo.GetAllAsync();
            return Ok(Products);
        }


        [HttpGet("id")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            return product;
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
