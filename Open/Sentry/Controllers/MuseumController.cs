using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Open.Sentry.Controllers
{
    public class MuseumController : Controller
    {
        public static string text;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InventoryIndex()
        {
            var Ocr = new IronOcr.AutoOcr();
            var Result = Ocr.Read(@"C:\Users\Asus\Downloads\img_20181213_134432.jpg");
            Console.WriteLine(Result.Text);
            text = Result.Text;
            return View();
        }
    }
}