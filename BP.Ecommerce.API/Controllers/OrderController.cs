using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP.Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBussinessLogicService service;

        public OrderController(IBussinessLogicService service)
        {
            this.service = service;
        }

        [HttpPost("CreateOrder")]
        public Task<OrderDto> CreateOrder(OrderCreateDto orderCreateDto)
        {
            return service.CreateOrder(orderCreateDto);
        }

        [HttpPost("AddProductOrder")]
        public Task<OrderDto> AddProductOrder(OrderProductCreateDto createOrderProduct)
        {
            return service.AddProductOrder(createOrderProduct);
        }

        [HttpDelete("RemoveOrderProducts/{idProduct}")]
        public Task<OrderDto> RemoveOrderProducts(Guid idProduct)
        {
            return service.RemoveOrderProducts(idProduct);
        }

        [HttpPut("UpdateProductQuantityOrder/{productId}/{quantity}")]
        public Task<OrderDto> UpdateProductQuantityOrder(int quantity, Guid productId)
        {
            return service.UpdateProductQuantityOrder(quantity, productId);
        }

        [HttpGet("ViewOrder/{id}")]
        public Task<OrderDto> ViewOrder(Guid id)
        {
            return service.ViewOrder(id);
        }

        [HttpPut("PayOrder/{id}")]
        public Task<OrderDto> PayOrder(Guid id)
        {
            return service.PayOrder(id);
        }

    }
}
