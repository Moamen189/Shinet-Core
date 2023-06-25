using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _storeContext;

        public ProductController(StoreContext storeContext)
        {
            this._storeContext = storeContext;
        }

        [HttpGet]

        public async Task< ActionResult<List<Product>>> GetProducts()
        {
            var Products = await _storeContext.Products.ToListAsync();
            return  Products ;
        }


        [HttpGet("id")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _storeContext.Products.FindAsync(id);
            return product;
        }
    }
}
