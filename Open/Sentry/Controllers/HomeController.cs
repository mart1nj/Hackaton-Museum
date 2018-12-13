using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Open.Data.User;
using Open.Domain.Museum;
using Open.Facade.Museum;
using Open.Sentry.Models;

namespace Open.Sentry.Controllers {
    public class HomeController : Controller {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IInventoriesRepository inventories;

        public HomeController(UserManager<ApplicationUser> uManager, IInventoriesRepository i) {
            userManager = uManager;
            inventories = i;
        }
        public async Task<IActionResult> Index() {
            var invs = await inventories.GetObjectsList();
            var invViewsList = new InventoryViewsList(invs);
            return View(invViewsList);
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