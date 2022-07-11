﻿using BP.Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Infraestructure.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {
                
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDeliveryMethod> ProductDeliveryMethods { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}
