using BP.Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Domain.RepositoryInterfaces
{
    public interface IDeliveryMethodRepository
    {
        Task<List<DeliveryMethod>> GetAllAsync(string search, int limit, int offset, string sort, string order);
        Task<DeliveryMethod> GetByIdAsync(Guid id);
        Task<DeliveryMethod> PostAsync(DeliveryMethod deliveryMethod);
        Task<DeliveryMethod> PutAsync(DeliveryMethod deliveryMethod);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
