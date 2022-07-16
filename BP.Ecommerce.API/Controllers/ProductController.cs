using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BP.Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        //[Authorize(Roles= "Admin, User")]
        [Authorize(Policy = "Ecuatoriano")]
        [HttpGet]
        public async Task<List<ProductDto>> GetAllAsync(string? search = "", int limit = 5, int offset = 0, string sort = "Name", string order = "asc")
        {
            return await _service.GetAllAsync(search, limit, offset, sort, order);
        }
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            return await _service.GetByIdAsync(id);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ProductDto> PostAsync(ProductDto productDto)
        {
            return await _service.PostAsync(productDto);

        }
        [Authorize(Roles = "Admin, Support")]
        [HttpPut]
        public async Task<ProductDto> PutAsync(ProductDto productDto)
        {
            return await _service.PutAsync(productDto);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _service.DeleteByIdAsync(id);
        }
    }
}
