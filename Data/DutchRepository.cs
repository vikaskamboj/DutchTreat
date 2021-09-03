using DutchTreat.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
	public class DutchRepository : IDutchRepository
	{
		private readonly DutchContext ctx;
		private readonly ILogger<DutchRepository> logger;

		public DutchRepository(DutchContext ctx, ILogger<DutchRepository> logger)
		{
			this.ctx = ctx;
			this.logger = logger;
		}

		public IEnumerable<Product> GetAllProducts()
		{
			try
			{
				return ctx.Products.OrderBy(x => x.Title).ToList();
			}
			catch (Exception ex) {
				logger.LogError($"Failed to get all products: {ex}");
				return null;
			}
		}

		public IEnumerable<Product> GetProductsByCategory(string category)
		{
			return ctx.Products.Where(x => x.Category == category).ToList();
		}

		public bool SaveAll()
		{
			return ctx.SaveChanges() > 0;
		}
	}
}
