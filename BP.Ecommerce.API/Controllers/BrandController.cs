using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP.Ecommerce.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _service;
        private ResponseDto response;

        public BrandController(IBrandService service)
        {
            _service = service;
            response = new ResponseDto();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetAllAsync(string? search = "", int limit = 5, int offset = 0, string sort = "Name", string order = "asc")
        {
            try
            {
                response.Result = await _service.GetAllAsync(search, limit, offset, sort, order);
            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string> { ex.Message };
                response.DisplayMessage = "Ocurrio un error al consultar";
                response.IsSuccess = false;
            }
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto>> GetByIdAsync(Guid id)
        {
            try
            {
                response.Result = await _service.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string> { ex.Message };
                response.DisplayMessage = "Ocurrio un error al consultar";
                response.IsSuccess = false;
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> PostAsync(BrandDto brandDto)
        {
            try
            {
                response.Result = await _service.PostAsync(brandDto);
                response.DisplayMessage = "Marca agregada con exito";
            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string> { ex.Message };
                response.DisplayMessage = "Ocurrio un error al agregar marca";
                response.IsSuccess = false;
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseDto>> PutAsync(BrandDto brandDto)
        {
            try
            {
                response.Result = await _service.PutAsync(brandDto);
                response.DisplayMessage = "Marca editada con exito";
            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string> { ex.Message };
                response.DisplayMessage = "Ocurrio un error al editar marca";
                response.IsSuccess = false;
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto>> DeleteByIdAsync(Guid id)
        {
            try
            {
                response.Result = await _service.DeleteByIdAsync(id);
                response.DisplayMessage = "Marca eliminada con exito";
            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string> { ex.Message };
                response.DisplayMessage = "Ocurrio un error al eliminar marca";
                response.IsSuccess = false;
            }
            return Ok(response);
        }
    }
}
