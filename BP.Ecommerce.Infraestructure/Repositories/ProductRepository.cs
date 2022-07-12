﻿using BP.Ecommerce.Domain.Entities;
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
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext _context;

        public ProductRepository(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<Product>> GetQueryable(string search, int limit, int offset, string sort, string order)
        {
            //Filter By Status
            var query = _context.Products.Where(b => b.Status == true);

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
                case "PRICE":
                    query = order.ToUpper() == "ASC"
                        ? query.OrderBy(b => b.Price)
                        : order.ToUpper() == "DESC"
                            ? query.OrderByDescending(b => b.Price)
                            : throw new ArgumentException($"Argumento: {order} no valido");
                    break;
                default:
                    throw new ArgumentException($"Argumento: {sort} no valido");
            }

            //pagination
            query = query.Skip(offset).Take(limit);

            return query;
        }

        public async Task<IQueryable<Product>> GetQueryableByIdAsync(Guid id)
        {
            var query = _context.Products.Where(b => b.Id == id && b.Status == true);
            Product productExist = await query.SingleOrDefaultAsync();
            if (productExist == null)
            {
                throw new Exception($"No existe producto con id: {id}");
            }
            return query;
        }

        public async Task<IQueryable<Product>> PostAsync(Product product)
        {
            var query = _context.Products.Where(b => b.Name == product.Name);
            var productExist = await query.SingleOrDefaultAsync();
            if (productExist != null)
            {
                throw new Exception($"Ya existe un producto: {productExist.Name}");
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return query;
        }

        public async Task<IQueryable<Product>> PutAsync(Product product)
        {
            var query = _context.Products.Where(b => b.Id == product.Id);
            bool productExist = _context.Products.Any(b => b.Id == product.Id && b.Status == true);
            if (!productExist)
            {
                throw new Exception($"No existe producto con id: {product.Id}");
            }
            product.ModificationDate = DateTime.Now;
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return query;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            Product productExist = await _context.Products.Where(b => b.Id == id && b.Status == true).SingleOrDefaultAsync();
            if (productExist == null)
            {
                throw new Exception($"No existe producto con id: {id}");
            }
            productExist.DeleteDate = DateTime.Now;
            productExist.Status = false;
            _context.Products.Update(productExist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
