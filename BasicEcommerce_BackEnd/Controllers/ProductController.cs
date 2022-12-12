using BasicEcommerce_BackEnd.Contracts;
using BasicEcommerce_BackEnd.Models;
using BasicEcommerce_BackEnd.Util;
using BasicEcommerce_BackEnd.Util.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BasicEcommerce_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Lazy<IProductService> LazyProductService;
        private IProductService ProductService => LazyProductService.Value;

        public ProductController(Lazy<IProductService> lazyProductService)
        {
            LazyProductService = lazyProductService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all products", Description = "Gets all products in stock")]
        [SwaggerResponse(200, Description = "Products list", Type = typeof(ICollection<Product>))]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.ProductService.GetAll());
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a product by id", Description = "Gets a product by id")]
        [SwaggerResponse(200, Description = "Product info", Type = typeof(Product))]
        public IActionResult Get(long id)
        {
            try
            {
                return Ok(this.ProductService.GetById(id));
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a product", Description = "Create a product")]
        [SwaggerResponse(200, Description = "Product created", Type = typeof(Product))]
        public IActionResult Post([FromBody] ProductRequest productRequest)
        {
            try
            {
                return Ok(this.ProductService.Create(productRequest));
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }

        [HttpPut()]
        [SwaggerOperation(Summary = "Update a product", Description = "Update a product")]
        [SwaggerResponse(200, Description = "Product updated", Type = typeof(Product))]
        public IActionResult Put([FromBody] ProductRequest productRequest)
        {
            try
            {
                return Ok(this.ProductService.Update(productRequest));
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a product by id", Description = "Delete a product by id")]
        [SwaggerResponse(200, Description = "Success messages", Type = typeof(string))]
        public IActionResult Delete(long id)
        {
            try
            {
                this.ProductService.Delete(id);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }
    }
}
