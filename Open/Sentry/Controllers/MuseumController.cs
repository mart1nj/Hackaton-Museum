﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Open.Sentry.Controllers
{
    public class MuseumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InventoryIndex()
        {
            return View();
        }
    }
}