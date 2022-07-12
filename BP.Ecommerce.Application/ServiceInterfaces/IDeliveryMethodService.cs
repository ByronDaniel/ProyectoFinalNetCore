using BP.Ecommerce.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Application.ServiceInterfaces
{
    public interface IDeliveryMethodService
    {
        /// <summary>
        /// Obtiene todas las metodo de entregas
        /// </summary>
        /// <returns></returns>
        Task<List<DeliveryMethodDto>> GetAllAsync(string search, int limit, int offset, string sort, string order);
            
        /// <summary>
        /// Obtiene metodo de entrega por Id
        /// </summary>
        /// <returns></returns>
        Task<DeliveryMethodDto> GetByIdAsync(Guid id);

        /// <summary>
        /// Agrega metodo de entrega
        /// </summary>
        /// <param name="deliveryMethodDto"></param>
        /// <returns></returns>
        Task<DeliveryMethodDto> PostAsync(DeliveryMethodDto deliveryMethodDto);

        /// <summary>
        /// Edita metodo de entrega
        /// </summary>
        /// <param name="deliveryMethodDto"></param>
        /// <returns></returns>
        Task<DeliveryMethodDto> PutAsync(DeliveryMethodDto deliveryMethodDto);

        /// <summary>
        /// Elimina metodo de entrega por Id
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteByIdAsync(Guid id);

    }
}
