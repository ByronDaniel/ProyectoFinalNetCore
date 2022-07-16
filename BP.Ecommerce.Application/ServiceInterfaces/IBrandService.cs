using BP.Ecommerce.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Application.ServiceInterfaces
{
    public interface IBrandService
    {
        /// <summary>
        /// Obtiene todas las marcas
        /// </summary>
        /// <returns></returns>
        Task<List<BrandDto>> GetAllAsync(string search, int limit, int offset, string sort, string order);

        /// <summary>
        /// Obtiene marca por Id
        /// </summary>
        /// <returns></returns>
        Task<BrandDto> GetByIdAsync(Guid id);

        /// <summary>
        /// Agrega marca
        /// </summary>
        /// <param name="brandDto"></param>
        /// <returns></returns>
        Task<BrandDto> PostAsync(CreateBrandDto createBrandDto);

        /// <summary>
        /// Edita marca
        /// </summary>
        /// <param name="brandDto"></param>
        /// <returns></returns>
        Task<BrandDto> PutAsync(BrandDto updateBrandDto);

        /// <summary>
        /// Elimina marca por Id
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteByIdAsync(Guid id);

    }
}
