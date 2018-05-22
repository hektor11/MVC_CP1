using Checkpoint1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Checkpoint1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            var userName = User.Identity.Name;
            var currentUser = context.Users.Where(u => u.UserName == userName).FirstOrDefault();
            ViewBag.Message = "Your contact page.";

            return View(currentUser);
        }
    }
}