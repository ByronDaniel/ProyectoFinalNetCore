using BP.Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Domain.RepositoryInterfaces
{
    public interface IProductDeliveryMethodRepository
    {
        Task<IQueryable<ProductDeliveryMethod>> GetQueryable(string search, int limit, int offset, string sort, string order);
        Task<IQueryable<ProductDeliveryMethod>> GetQueryableByIdAsync(int id);
        Task<IQueryable<ProductDeliveryMethod>> PostAsync(ProductDeliveryMethod productDeliveryMethod);
        Task<IQueryable<ProductDeliveryMethod>> PutAsync(ProductDeliveryMethod productDeliveryMethod);
        Task<bool> DeleteByIdAsync(int id);
    }
}
