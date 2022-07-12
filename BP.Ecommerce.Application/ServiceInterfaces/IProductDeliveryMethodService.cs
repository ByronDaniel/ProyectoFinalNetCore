using BP.Ecommerce.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Application.ServiceInterfaces
{
    public interface IProductDeliveryMethodService
    {
        /// <summary>
        /// Obtiene todas las informacion de entrega
        /// </summary>
        /// <returns></returns>
        Task<List<ProductDeliveryMethodDto>> GetAllAsync(string search, int limit, int offset, string sort, string order);
            
        /// <summary>
        /// Obtiene informacion de entrega por Id
        /// </summary>
        /// <returns></returns>
        Task<ProductDeliveryMethodDto> GetByIdAsync(int id);

        /// <summary>
        /// Agrega informacion de entrega
        /// </summary>
        /// <param name="productDeliveryMethodDto"></param>
        /// <returns></returns>
        Task<ProductDeliveryMethodDto> PostAsync(ProductDeliveryMethodDto productDeliveryMethodDto);

        /// <summary>
        /// Edita informacion de entrega
        /// </summary>
        /// <param name="productDeliveryMethodDto"></param>
        /// <returns></returns>
        Task<ProductDeliveryMethodDto> PutAsync(ProductDeliveryMethodDto productDeliveryMethodDto);

        /// <summary>
        /// Elimina informacion de entrega por Id
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteByIdAsync(int id);

    }
}
