
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

        public ProductController(IProductRepository ProductRepository)
        {
          
            _productRepository = ProductRepository;
        }

        [HttpGet]

        public async Task< ActionResult<List<Product>>> GetProducts()
        {
            var Products = await _productRepository.GetProductsAsync();
            return Ok(Products);
        }


        [HttpGet("id")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return product;
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductsBrand()
        {
            var ProductBrand = await _productRepository.GetProductBrandAsync();

            return Ok(ProductBrand);
        }

        [HttpGet("types")]

        public async Task<ActionResult<List<ProductType>>> GetProductsTypes()
        {
            var ProductTypes = await _productRepository.GetProductTypeAsync();

            return Ok (ProductTypes);
        }
    }
}
