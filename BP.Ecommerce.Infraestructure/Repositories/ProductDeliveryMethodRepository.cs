using BP.Ecommerce.Domain.Entities;
using BP.Ecommerce.Domain.RepositoryInterfaces;
using BP.Ecommerce.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Infraestructure.Repositories
{
    public class ProductDeliveryMethodRepository : IProductDeliveryMethodRepository
    {
        private readonly EcommerceDbContext _context;

        public ProductDeliveryMethodRepository(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<ProductDeliveryMethod>> GetQueryable(string search, int limit, int offset, string sort, string order)
        {
            //Filter By Status
            var query = _context.ProductDeliveryMethods.Where(b => b.Status == true);

            //Sort and Order
            switch (sort.ToUpper())
            {
                case "PRODUCTID":
                    query = order.ToUpper() == "ASC" 
                        ? query.OrderBy(b => b.ProductId) 
                        : order.ToUpper() == "DESC" 
                            ? query.OrderByDescending(b => b.ProductId) 
                            : throw new ArgumentException($"Argumento: {order} no valido");
                    break;
                case "DELIVERYMETHODID":
                    query = order.ToUpper() == "ASC"
                        ? query.OrderBy(b => b.DeliveryMethodId)
                        : order.ToUpper() == "DESC"
                            ? query.OrderByDescending(b => b.DeliveryMethodId)
                            : throw new ArgumentException($"Argumento: {order} no valido");
                    break;
                default:
                    throw new ArgumentException($"Argumento: {sort} no valido");
            }

            //pagination
            query = query.Skip(offset).Take(limit);

            return query;
        }

        public async Task<IQueryable<ProductDeliveryMethod>> GetQueryableByIdAsync(int id)
        {
            var query = _context.ProductDeliveryMethods.Where(b => b.Id == id && b.Status == true);
            ProductDeliveryMethod productDeliveryMethodExist = await query.SingleOrDefaultAsync();
            if (productDeliveryMethodExist == null)
            {
                throw new Exception($"No existe Informacion de entrega con id: {id}");
            }
            return query;
        }

        public async Task<IQueryable<ProductDeliveryMethod>> PostAsync(ProductDeliveryMethod productDeliveryMethod)
        {
            var query = _context.ProductDeliveryMethods.Where(b => b.ProductId == productDeliveryMethod.ProductId && b.DeliveryMethodId == productDeliveryMethod.DeliveryMethodId && b.Status == true);
            var productDeliveryMethodExist = await query.SingleOrDefaultAsync();
            if (productDeliveryMethodExist != null)
            {
                throw new Exception($"Ya existe un Informacion de entrega");
            }
            await _context.ProductDeliveryMethods.AddAsync(productDeliveryMethod);
            await _context.SaveChangesAsync();
            return query;
        }

        public async Task<IQueryable<ProductDeliveryMethod>> PutAsync(ProductDeliveryMethod productDeliveryMethod)
        {
            var query = _context.ProductDeliveryMethods.Where(b => b.Id == productDeliveryMethod.Id);
            bool productDeliveryMethodExist = _context.ProductDeliveryMethods.Any(b => b.Id == productDeliveryMethod.Id && b.Status == true);
            if (!productDeliveryMethodExist)
            {
                throw new Exception($"No existe Informacion de entrega con id: {productDeliveryMethod.Id}");
            }
            productDeliveryMethod.ModificationDate = DateTime.Now;
            _context.Entry(productDeliveryMethod).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return query;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            ProductDeliveryMethod productDeliveryMethodExist = await _context.ProductDeliveryMethods.Where(b => b.Id == id && b.Status == true).SingleOrDefaultAsync();
            if (productDeliveryMethodExist == null)
            {
                throw new Exception($"No existe Informacion de entrega con id: {id}");
            }
            productDeliveryMethodExist.DeleteDate = DateTime.Now;
            productDeliveryMethodExist.Status = false;
            _context.ProductDeliveryMethods.Update(productDeliveryMethodExist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
