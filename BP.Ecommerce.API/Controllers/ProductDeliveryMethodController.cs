using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BP.Ecommerce.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDeliveryMethodController : ControllerBase
    {
        private readonly IProductDeliveryMethodService _service;

        public ProductDeliveryMethodController(IProductDeliveryMethodService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<ProductDeliveryMethodDto>> GetAllAsync(string? search = "", int limit = 5, int offset = 0, string sort = "Name", string order = "asc")
        {
            return await _service.GetAllAsync(search, limit, offset, sort, order);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ProductDeliveryMethodDto> GetByIdAsync(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ProductDeliveryMethodDto> PostAsync(ProductDeliveryMethodDto productDeliveryMethodDto)
        {
            return await _service.PostAsync(productDeliveryMethodDto);
        }

        [HttpPut]
        public async Task<ProductDeliveryMethodDto> PutAsync(ProductDeliveryMethodDto productDeliveryMethodDto)
        {
            return await _service.PutAsync(productDeliveryMethodDto);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _service.DeleteByIdAsync(id);
        }
    }
}
