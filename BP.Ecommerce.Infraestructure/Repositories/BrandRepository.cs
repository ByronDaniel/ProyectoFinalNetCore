using BP.Ecommerce.Domain.Entities;
using BP.Ecommerce.Domain.Repositories;
using BP.Ecommerce.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Infraestructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly EcommerceDbContext _context;

        public BrandRepository(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<List<Brand>> GetAllAsync(string search, int limit, int offset, string sort, string order)
        {
            //Filter By Status
            var query = _context.Brands.Where(b => b.Status == true);

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

        public async Task<Brand> GetByIdAsync(Guid id)
        {
            Brand brandExist = await _context.Brands.Where(b => b.Id == id && b.Status == true).SingleOrDefaultAsync();
            if (brandExist == null)
            {
                throw new Exception($"No existe marca con id: {id}");
            }
            return brandExist;
        }

        public async Task<Brand> PostAsync(Brand brand)
        {
            var brandExist = await _context.Brands.Where(b => b.Name == brand.Name).SingleOrDefaultAsync();
            if (brandExist != null)
            {
                throw new Exception($"Ya existe una marca: {brandExist.Name}");
            }
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<Brand> PutAsync(Brand brand)
        {
            bool brandExist = _context.Brands.Any(b => b.Id == brand.Id && b.Status == true);
            if (!brandExist)
            {
                throw new Exception($"No existe marca con id: {brand.Id}");
            }
            brand.ModificationDate = DateTime.Now;
            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            Brand brandExist = await _context.Brands.Where(b => b.Id == id && b.Status == true).SingleOrDefaultAsync();
            if (brandExist == null)
            {
                throw new Exception($"No existe marca con id: {id}");
            }
            brandExist.DeleteDate = DateTime.Now;
            brandExist.Status = false;
            _context.Brands.Update(brandExist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
