using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shopping.Api.Data;
using Shopping.Api.Models;

namespace Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ILogger<ProductController> logger, ProductContext context) : ControllerBase
    {
        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            logger.LogInformation("Fetching all products");
            var product = await context.Products.Find(p => true).ToListAsync();
            return Ok(product);
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetOne(string id)
        {
            logger.LogInformation($"Fetching product with ID: {id}");
            var product = await context.Products.FindAsync(p => p.Id == id);

            if (product == null)
            {
               logger.LogWarning($"Product with ID: {id} not found");
                return NotFound();
            }

            return Ok(product);
        }
    }
}