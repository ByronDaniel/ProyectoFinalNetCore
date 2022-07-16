using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BP.Ecommerce.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryMethodController : ControllerBase
    {
        private readonly IDeliveryMethodService _service;

        public DeliveryMethodController(IDeliveryMethodService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<DeliveryMethodDto>> GetAllAsync(string? search = "", int limit = 5, int offset = 0, string sort = "Name", string order = "asc")
        {
            return await _service.GetAllAsync(search, limit, offset, sort, order);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<DeliveryMethodDto> GetByIdAsync(Guid id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<DeliveryMethodDto> PostAsync(CreateDeliveryMethodDto createDeliveryMethodDto)
        {
            return await _service.PostAsync(createDeliveryMethodDto);
        }

        [HttpPut]
        public async Task<DeliveryMethodDto> PutAsync(DeliveryMethodDto deliveryMethodDto)
        {
            return await _service.PutAsync(deliveryMethodDto);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _service.DeleteByIdAsync(id);
        }
    }
}
