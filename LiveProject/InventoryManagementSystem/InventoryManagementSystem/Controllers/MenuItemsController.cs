using InventoryManagementSystem.DAL;
using InventoryManagementSystem.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class MenuItemsController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: MenuItems
        public ActionResult Index(string search, string sortOrder, string currentFilter)
        {

            ViewBag.CurrentFilter = search;

            if (search == null)
            {
                search = currentFilter;
            }

            var menuItems = from m in db.MenuItems
                            select m;

            if (!String.IsNullOrEmpty(search))
            {
                menuItems = menuItems.Where(m => m.Name.Contains(search));

            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CostSortParm = sortOrder == "price" ? "price_desc" : "price";

            switch (sortOrder)
            {
                case "name_desc":
                    menuItems = menuItems.OrderByDescending(i => i.Name);
                    break;
                case "price":
                    menuItems = menuItems.OrderBy(i => i.Price);
                    break;
                case "price_desc":
                    menuItems = menuItems.OrderByDescending(i => i.Price);
                    break;
                default:
                    menuItems = menuItems.OrderBy(i => i.Name);
                    break;
            }

            return View(/*db.MenuItems.ToList(), */menuItems);
        }

        // GET: MenuItems/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // GET: MenuItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                menuItem.ID = Guid.NewGuid();
                db.MenuItems.Add(menuItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuItem);
        }

        // GET: MenuItems/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // POST: MenuItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuItem);
        }

        // GET: MenuItems/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            MenuItem menuItem = db.MenuItems.Find(id);
            db.MenuItems.Remove(menuItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
