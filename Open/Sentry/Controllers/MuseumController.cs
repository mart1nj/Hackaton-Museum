using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Museum;
using Open.Domain.Museum;
using Open.Facade.Museum;
namespace Open.Sentry.Controllers
{
    public class MuseumController : Controller
    {
        private readonly IMusealsRepository museals;
        private readonly IInventoryMusealsRepository inventoryMuseals;
        private readonly IInventoriesRepository inventories;
        internal const string musealProperties =
            "ID, MusealID, Author, Designation, Info, StateBefore, DamagesBefore, " +
            "DefaultLocation, CurrentLocation, ValidFrom, ValidTo";
        internal const string inventoryProperties = "ID, Employee, ValidFrom, ValidTo";

        public MuseumController(IMusealsRepository mus, IInventoryMusealsRepository invMus, IInventoriesRepository inv)
        {
            museals = mus;
            inventoryMuseals = invMus;
            inventories = inv;
        }
        public async Task<IActionResult> InventoryMusealsIndex(string inventoryId, string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortMusealID"] = string.IsNullOrEmpty(sortOrder) ? "musealID_desc" : "";
            ViewData["SortAuthor"] = sortOrder == "author" ? "author" : "senderAccount";

            //TODO muud sortid ka

            museals.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            museals.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            museals.SearchString = searchString;
            museals.PageIndex = page ?? 1;
            ViewBag.InventoryNumber = inventoryId;
            var invMus = await inventoryMuseals.GetInventoryMusealsList(inventoryId);
            var mus = await museals.GetObjectsList();
            var viewList = new InventoryMusealViewsList(invMus, mus);
            return View(viewList);
        }
        private Func<MusealData, object> getSortFunction(string sortOrder)
        {

            //TODO Fix

            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.ID;
            if (sortOrder.StartsWith("validTo")) return x => x.ValidTo;
            if (sortOrder.StartsWith("validFrom")) return x => x.ValidFrom;
            if (sortOrder.StartsWith("alpha3")) return x => x.ID;
            return x => x.ID;
        }
        public async Task<IActionResult> MusealsIndex(string sortOrder = null, string currentFilter = null,
            string searchString = null, int? page = null)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortMusealID"] = string.IsNullOrEmpty(sortOrder) ? "musealID_desc" : "";
            ViewData["SortAuthor"] = sortOrder == "author" ? "author" : "senderAccount";

            //TODO muud sortid ka

            museals.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            museals.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            museals.SearchString = searchString;
            museals.PageIndex = page ?? 1;
            var mus = await museals.GetObjectsList();
            var viewList = new MusealViewsList(mus);
            return View(viewList);
        }

        public IActionResult CreateInventory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventory([Bind(inventoryProperties)] InventoryView c) {
            c.ID = Guid.NewGuid().ToString();
            var d = new InventoryData() { ID = c.ID, Employee = c.Employee, ValidTo = c.ValidTo ?? DateTime.MaxValue, ValidFrom = c.ValidFrom ?? DateTime.MinValue };
            var o = new Inventory(d);
            await inventories.AddObject(o);
            await generateInventoryMuseals(d.ID);
            return RedirectToAction("Index", "Home");
        }

        private async Task generateInventoryMuseals(string inventoryID) {
            var mus = await museals.GetObjectsList();
            foreach (var museal in mus) {
                var invMusData = new InventoryMusealData { InventoryID = inventoryID, MusealID = museal?.Data?.ID };
                var invMusObj = new InventoryMuseal(invMusData);
                await inventoryMuseals.AddObject(invMusObj);
            }
        }
        public IActionResult CreateMuseal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMuseal([Bind(musealProperties)] MusealView c)
        {
            c.ID = c.ID ?? Guid.NewGuid().ToString();
            if (c.ID == "Unspecified") c.ID = Guid.NewGuid().ToString();
            var d = new MusealData {
                ID = c.ID, Author = c.Author, Designation = c.Designation, Info = c.Info,
                StateBefore = c.StateBefore, DamagesBefore = c.DamagesBefore,
                CurrentLocation = c.CurrentLocation, DefaultLocation = c.DefaultLocation,
                ValidTo = c.ValidTo ?? DateTime.MaxValue,
                ValidFrom = c.ValidFrom ?? DateTime.MinValue
            };
            var o = new Museal(d);
            await museals.AddObject(o);
            return RedirectToAction("MusealsIndex");
        }
    }
}