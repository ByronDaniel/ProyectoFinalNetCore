using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BP.Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandController(IBrandService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<BrandDto>> GetAllAsync(string? search = "", int limit = 5, int offset = 0, string sort = "Name", string order = "asc")
        {
            return await _service.GetAllAsync(search, limit, offset, sort, order);
        }

        [HttpGet("{id}")]
        public async Task<BrandDto> GetByIdAsync(Guid id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<BrandDto> PostAsync(CreateBrandDto createBrandDto)
        {
            return await _service.PostAsync(createBrandDto);
        }

        [HttpPut]
        public async Task<BrandDto> PutAsync(BrandDto brandDto)
        {
            return await _service.PutAsync(brandDto);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _service.DeleteByIdAsync(id);
        }
    }
}
