using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BP.Ecommerce.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _service;

        public ProductTypeController(IProductTypeService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<ProductTypeDto>> GetAllAsync(string? search = "", int limit = 5, int offset = 0, string sort = "Name", string order = "asc")
        {
            return await _service.GetAllAsync(search, limit, offset, sort, order);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ProductTypeDto> GetByIdAsync(Guid id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ProductTypeDto> PostAsync(ProductTypeDto productTypeDto)
        {
            return await _service.PostAsync(productTypeDto);
        }

        [HttpPut]
        public async Task<ProductTypeDto> PutAsync(ProductTypeDto productTypeDto)
        {
            return await _service.PutAsync(productTypeDto);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _service.DeleteByIdAsync(id);
        }
    }
}
