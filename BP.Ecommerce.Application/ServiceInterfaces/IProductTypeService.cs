using BP.Ecommerce.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Application.ServiceInterfaces
{
    public interface IProductTypeService
    {
        /// <summary>
        /// Obtiene todas las tipo de productos
        /// </summary>
        /// <returns></returns>
        Task<List<ProductTypeDto>> GetAllAsync(string search, int limit, int offset, string sort, string order);
            
        /// <summary>
        /// Obtiene tipo de producto por Id
        /// </summary>
        /// <returns></returns>
        Task<ProductTypeDto> GetByIdAsync(Guid id);

        /// <summary>
        /// Agrega tipo de producto
        /// </summary>
        /// <param name="productTypeDto"></param>
        /// <returns></returns>
        Task<ProductTypeDto> PostAsync(ProductTypeDto productTypeDto);

        /// <summary>
        /// Edita tipo de producto
        /// </summary>
        /// <param name="productTypeDto"></param>
        /// <returns></returns>
        Task<ProductTypeDto> PutAsync(ProductTypeDto productTypeDto);

        /// <summary>
        /// Elimina tipo de producto por Id
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteByIdAsync(Guid id);

    }
}
