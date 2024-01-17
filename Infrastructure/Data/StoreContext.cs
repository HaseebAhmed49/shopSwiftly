using System;
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

		// Not using at the moment - 17-01-2024
//		public DbSet<ProductBrand> ProductBrands { get; set; }

		public DbSet<ProductType> ProductTypes { get; set; }
	}
}

