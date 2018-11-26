using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Open.Data.Bank;
using Open.Domain.Bank;
using Open.Facade.Bank;
using Open.Sentry.Models;

namespace Open.Sentry.Controllers {
    public class HomeController : Controller {
        private readonly IAccountsRepository accounts;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IAccountsRepository a, UserManager<ApplicationUser> uManager) {
            accounts = a;
            userManager = uManager;
        }
        public async Task<IActionResult> Index() {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            if (loggedInUser == null) return View();
            var bankAccounts = await accounts.LoadAccountsForUser(loggedInUser.Id);
            var bankAccountsViewsList = new AccountsViewsList(bankAccounts);
            return View(bankAccountsViewsList);

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