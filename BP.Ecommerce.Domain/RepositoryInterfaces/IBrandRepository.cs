using BP.Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Domain.RepositoryInterfaces
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAllAsync(string search, int limit, int offset, string sort, string order);
        Task<Brand> GetByIdAsync(Guid id);
        Task<Brand> PostAsync(Brand brand);
        Task<Brand> PutAsync(Brand brand);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
