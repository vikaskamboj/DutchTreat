using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace DutchTreat.Data
{
    public class DutchContext : DbContext
    {
		private readonly IConfiguration config;

		public DutchContext(IConfiguration config)
		{
			this.config = config;
		}

		public DbSet<Product> Products { get; set; }
        
        public DbSet<Order> Orders { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseSqlServer(config["ConnectionStrings:DutchContextDb"]);
		}
		

	}
}
