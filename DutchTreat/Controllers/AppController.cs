using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        public IMailService _mailService { get; }
        public IDutchRepository _repo { get; }

        public AppController(IMailService mailService, IDutchRepository repository)
        {
            _mailService = mailService;
            _repo = repository;
        }

        public IActionResult Index() => View();

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send email
                _mailService.SendMessage("test@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message {model.Message}");
                ViewBag.UserMessage = "Mail sent";
                ModelState.Clear();
            }

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About us";

            return View();
        }

        [Authorize]
        public IActionResult Shop()
        {
            var results = _repo.GetAllProducts();

            return View(results);
        }
    }
}
