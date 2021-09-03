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
		private readonly IDutchRepository repo;

		public AppController(IMailService mailService, IDutchRepository repo)
		{
            this.mailService = mailService;
			this.repo = repo;
		}

		public IActionResult Index()
        {
            var prodList  = repo.GetAllProducts();
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
            var results = repo.GetAllProducts();

            return View(results);
        }
    }
}
