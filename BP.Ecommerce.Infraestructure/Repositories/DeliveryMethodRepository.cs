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
    public class DeliveryMethodRepository : IDeliveryMethodRepository
    {
        private readonly EcommerceDbContext _context;

        public DeliveryMethodRepository(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<List<DeliveryMethod>> GetAllAsync(string search, int limit, int offset, string sort, string order)
        {
            //Filter By Status
            var query = _context.DeliveryMethods.Where(b => b.Status == true);

            //Search
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(b => b.Name.ToUpper().Contains(search.ToUpper()));
            }

            //Sort and Order
            switch (sort.ToUpper())
            {
                case "NAME":
                    query = order.ToUpper() == "ASC" 
                        ? query.OrderBy(b => b.Name) 
                        : order.ToUpper() == "DESC" 
                            ? query.OrderByDescending(b => b.Name) 
                            : throw new ArgumentException($"Argumento: {order} no valido");
                    break;
                case "DESCRIPTION":
                    query = order.ToUpper() == "ASC"
                        ? query.OrderBy(b => b.Description)
                        : order.ToUpper() == "DESC"
                            ? query.OrderByDescending(b => b.Description)
                            : throw new ArgumentException($"Argumento: {order} no valido");
                    break;
                default:
                    throw new ArgumentException($"Argumento: {sort} no valido");
            }

            //pagination
            query = query.Skip(offset).Take(limit);

            return await query.ToListAsync();
        }

        public async Task<DeliveryMethod> GetByIdAsync(Guid id)
        {
            DeliveryMethod deliveryMethodExist = await _context.DeliveryMethods.Where(b => b.Id == id && b.Status == true).SingleOrDefaultAsync();
            if (deliveryMethodExist == null)
            {
                throw new Exception($"No existe metodo de entrega con id: {id}");
            }
            return deliveryMethodExist;
        }

        public async Task<DeliveryMethod> PostAsync(DeliveryMethod deliveryMethod)
        {
            var deliveryMethodExist = await _context.DeliveryMethods.Where(b => b.Name == deliveryMethod.Name).SingleOrDefaultAsync();
            if (deliveryMethodExist != null)
            {
                throw new Exception($"Ya existe un metodo de entrega: {deliveryMethodExist.Name}");
            }
            await _context.DeliveryMethods.AddAsync(deliveryMethod);
            await _context.SaveChangesAsync();
            return deliveryMethod;
        }

        public async Task<DeliveryMethod> PutAsync(DeliveryMethod deliveryMethod)
        {
            bool deliveryMethodExist = _context.DeliveryMethods.Any(b => b.Id == deliveryMethod.Id && b.Status == true);
            if (!deliveryMethodExist)
            {
                throw new Exception($"No existe metodo de entrega con id: {deliveryMethod.Id}");
            }
            deliveryMethod.ModificationDate = DateTime.Now;
            _context.Entry(deliveryMethod).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return deliveryMethod;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            DeliveryMethod deliveryMethodExist = await _context.DeliveryMethods.Where(b => b.Id == id && b.Status == true).SingleOrDefaultAsync();
            if (deliveryMethodExist == null)
            {
                throw new Exception($"No existe metodo de entrega con id: {id}");
            }
            deliveryMethodExist.DeleteDate = DateTime.Now;
            deliveryMethodExist.Status = false;
            _context.DeliveryMethods.Update(deliveryMethodExist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
