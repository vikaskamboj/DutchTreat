using DutchTreat.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IDutchRepository _repo;
		private readonly ILogger<ProductsController> _logger;

		public ProductsController(IDutchRepository repo, ILogger<ProductsController> logger)
		{
			_repo = repo;
			_logger = logger;
		}
	}
}
