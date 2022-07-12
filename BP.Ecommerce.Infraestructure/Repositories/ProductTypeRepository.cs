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
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly EcommerceDbContext _context;

        public ProductTypeRepository(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductType>> GetAllAsync(string search, int limit, int offset, string sort, string order)
        {
            //Filter By Status
            var query = _context.ProductTypes.Where(b => b.Status == true);

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
                default:
                    throw new ArgumentException($"Argumento: {sort} no valido");
            }

            //pagination
            query = query.Skip(offset).Take(limit);

            return await query.ToListAsync();
        }

        public async Task<ProductType> GetByIdAsync(Guid id)
        {
            ProductType productTypeExist = await _context.ProductTypes.Where(b => b.Id == id && b.Status == true).SingleOrDefaultAsync();
            if (productTypeExist == null)
            {
                throw new Exception($"No existe tipo de producto con id: {id}");
            }
            return productTypeExist;
        }

        public async Task<ProductType> PostAsync(ProductType productType)
        {
            var productTypeExist = await _context.ProductTypes.Where(b => b.Name == productType.Name).SingleOrDefaultAsync();
            if (productTypeExist != null)
            {
                throw new Exception($"Ya existe un tipo de producto: {productTypeExist.Name}");
            }
            await _context.ProductTypes.AddAsync(productType);
            await _context.SaveChangesAsync();
            return productType;
        }

        public async Task<ProductType> PutAsync(ProductType productType)
        {
            bool productTypeExist = _context.ProductTypes.Any(b => b.Id == productType.Id && b.Status == true);
            if (!productTypeExist)
            {
                throw new Exception($"No existe tipo de producto con id: {productType.Id}");
            }
            productType.ModificationDate = DateTime.Now;
            _context.Entry(productType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return productType;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            ProductType productTypeExist = await _context.ProductTypes.Where(b => b.Id == id && b.Status == true).SingleOrDefaultAsync();
            if (productTypeExist == null)
            {
                throw new Exception($"No existe tipo de producto con id: {id}");
            }
            productTypeExist.DeleteDate = DateTime.Now;
            productTypeExist.Status = false;
            _context.ProductTypes.Update(productTypeExist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
