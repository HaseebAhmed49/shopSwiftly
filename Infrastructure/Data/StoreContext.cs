using System;
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class StoreContext : DbContext
	{
		public StoreContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Product> Products { get; set; }

		public DbSet<ProductBrand> ProductBrands { get; set; }

		public DbSet<ProductType> ProductTypes { get; set; }

		// this will get the updated properties from the Infrastruture/Data/Config/ProductConfiguration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}