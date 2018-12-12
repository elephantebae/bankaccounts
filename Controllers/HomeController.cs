using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using bankaccounts.Models;

using System.Threading.Tasks;

namespace bankaccounts.Controllers
{
    public class HomeController : Controller
    {
        private BankContext dbContext;
        public HomeController(BankContext context)
        {
            dbContext = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Registering")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {

                HttpContext.Session.SetString("Username", user.FirstName);
                HttpContext.Session.SetInt32("id", user.UserId);
                dbContext.user.Add(user);
                dbContext.SaveChanges();
                return RedirectToAction("Account");
            }
            return View("index");
        }

        [HttpGet]
        [Route("Account/")]
        public IActionResult Account()
        {
            int? id = HttpContext.Session.GetInt32("id");
            User currentuser = dbContext.user
            .Include(user => user.Transactions)
            .Where(user => user.UserId == id).SingleOrDefault();
            ViewBag.CurrentUser = currentuser;
            return View();
        }
    }  
}
