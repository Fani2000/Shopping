using Microsoft.AspNetCore.Mvc;
using Shopping.Client.Models;

namespace Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ILogger<ProductController> logger) : ControllerBase
    {
        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            logger.LogInformation("Fetching all products");
            return Ok(ProductContext.Products);
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetOne(string id)
        {
            logger.LogInformation($"Fetching product with ID: {id}");
            var product = ProductContext.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
               logger.LogWarning($"Product with ID: {id} not found");
                return NotFound();
            }

            return Ok(product);
        }
    }
}