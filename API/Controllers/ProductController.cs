﻿
using API.Dtos;
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

        public async Task< ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductWithTypesAndBrandSpecification();
            var Products = await _productRepo.GetListWithSpec(spec);
            return Products.Select(product => new ProductToReturnDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name,
            }).ToList();
        }


        [HttpGet("id")]

        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            return new ProductToReturnDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name,



            };
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
