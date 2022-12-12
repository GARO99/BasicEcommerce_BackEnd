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
    public class OrderController : ControllerBase
    {
        private readonly Lazy<IOrderService> LazyOrderService;
        private IOrderService OrderService => LazyOrderService.Value;

        public OrderController(Lazy<IOrderService> lazyOrderService)
        {
            LazyOrderService = lazyOrderService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all orders", Description = "Gets all orders")]
        [SwaggerResponse(200, Description = "Orders list", Type = typeof(ICollection<Order>))]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.OrderService.GetAll());
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a order by id", Description = "Gets a order by id")]
        [SwaggerResponse(200, Description = "Order info", Type = typeof(Order))]
        public IActionResult Get(long id)
        {
            try
            {
                return Ok(this.OrderService.GetById(id));
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a order", Description = "Create a order")]
        [SwaggerResponse(200, Description = "Order info", Type = typeof(Client))]
        public IActionResult Post(OrderRequest orderRequest)
        {
            try
            {
                return Ok(this.OrderService.Create(orderRequest));
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }
    }
}
