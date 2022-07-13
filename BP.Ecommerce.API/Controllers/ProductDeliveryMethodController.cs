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
    public class ProductDeliveryMethodController : ControllerBase
    {
        private readonly IProductDeliveryMethodService _service;
        private ResponseDto response;

        public ProductDeliveryMethodController(IProductDeliveryMethodService service)
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
        public async Task<ActionResult<ResponseDto>> GetByIdAsync(int id)
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
        public async Task<ActionResult<ResponseDto>> PostAsync(ProductDeliveryMethodDto productDeliveryMethodDto)
        {
            try
            {
                response.Result = await _service.PostAsync(productDeliveryMethodDto);
                response.DisplayMessage = "Informacion de entrega agregado con exito";
            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string> { ex.Message };
                response.DisplayMessage = "Ocurrio un error al agregar informacion de entrega";
                response.IsSuccess = false;
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseDto>> PutAsync(ProductDeliveryMethodDto productDeliveryMethodDto)
        {
            try
            {
                response.Result = await _service.PutAsync(productDeliveryMethodDto);
                response.DisplayMessage = "Informacion de entrega editado con exito";
            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string> { ex.Message };
                response.DisplayMessage = "Ocurrio un error al editar informacion de entrega";
                response.IsSuccess = false;
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto>> DeleteByIdAsync(int id)
        {
            try
            {
                response.Result = await _service.DeleteByIdAsync(id);
                response.DisplayMessage = "Informacion de entrega eliminado con exito";
            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string> { ex.Message };
                response.DisplayMessage = "Ocurrio un error al eliminar informacion de entrega";
                response.IsSuccess = false;
            }
            return Ok(response);
        }
    }
}
