using BP.Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Domain.RepositoryInterfaces
{
    public interface IProductTypeRepository
    {
        Task<List<ProductType>> GetAllAsync(string search, int limit, int offset, string sort, string order);
        Task<ProductType> GetByIdAsync(Guid id);
        Task<ProductType> PostAsync(ProductType productType);
        Task<ProductType> PutAsync(ProductType productType);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
