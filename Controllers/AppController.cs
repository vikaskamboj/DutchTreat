using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.ViewModels;
using DutchTreat.Services;
using DutchTreat.Data;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService mailService;
		private readonly DutchContext context;

		public AppController(IMailService mailService, DutchContext context)
		{
            this.mailService = mailService;
			this.context = context;
		}

		public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";

            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the email
                mailService.SendMessage("abc@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }

            ViewBag.Title = "Contact Us";

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About us";
            return View();
        }

        public IActionResult Shop()
        {
            var results = context.Products
                .OrderBy(x => x.Category)
                .ToList();

            return View(results);
        }
    }
}
