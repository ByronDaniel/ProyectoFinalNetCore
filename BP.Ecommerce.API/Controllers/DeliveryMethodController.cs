using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP.Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryMethodController : ControllerBase
    {
        private readonly IDeliveryMethodService _service;
        private ResponseDto response;

        public DeliveryMethodController(IDeliveryMethodService service)
        {
            _service = service;
            response = new ResponseDto();
        }

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
        public async Task<ActionResult<ResponseDto>> PostAsync(DeliveryMethodDto deliveryMethodDto)
        {
            try
            {
                response.Result = await _service.PostAsync(deliveryMethodDto);
                response.DisplayMessage = "Metodo de entrega agregada con exito";
            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string> { ex.Message };
                response.DisplayMessage = "Ocurrio un error al agregar metodo de entrega";
                response.IsSuccess = false;
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseDto>> PutAsync(DeliveryMethodDto deliveryMethodDto)
        {
            try
            {
                response.Result = await _service.PutAsync(deliveryMethodDto);
                response.DisplayMessage = "Metodo de entrega editada con exito";
            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string> { ex.Message };
                response.DisplayMessage = "Ocurrio un error al editar metodo de entrega";
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
                response.DisplayMessage = "Metodo de entrega eliminada con exito";
            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string> { ex.Message };
                response.DisplayMessage = "Ocurrio un error al eliminar metodo de entrega";
                response.IsSuccess = false;
            }
            return Ok(response);
        }
    }
}
