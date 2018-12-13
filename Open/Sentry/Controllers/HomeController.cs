using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Open.Data.User;
using Open.Sentry.Models;

namespace Open.Sentry.Controllers {
    public class HomeController : Controller {
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(UserManager<ApplicationUser> uManager) {
            userManager = uManager;
        }
        public async Task<IActionResult> Index() {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            if (loggedInUser == null) return View();
            return View();

        }
        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error() {
            return View(new ErrorViewModel {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}