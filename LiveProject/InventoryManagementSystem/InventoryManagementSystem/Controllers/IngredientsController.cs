using InventoryManagementSystem.DAL;
using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class IngredientsController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Ingredients
        public ActionResult Index(string category, string sortOrder, string currentFilter)
        {


            if (category == null)
            {
                category = currentFilter;
            }

            ViewBag.CurrentFilter = category;

            var categoryList = new List<string>();


            var categoryQuery = db.Ingredients.Select(c => c.Category.ToString()).Distinct();


            ViewBag.Category = new SelectList(categoryQuery);


            var ingredients = from i in db.Ingredients
                              select i;


            if (category != null && category != "" && !string.IsNullOrEmpty(categoryQuery.ToString()))
            {
                ingredients = ingredients.Where(i => i.Category.ToString() == category);
            }



            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CostSortParm = sortOrder == "cost" ? "cost_desc" : "cost";
            ViewBag.CategorySortParm = sortOrder == "category" ? "category_desc" : "category";

            switch (sortOrder)
            {
                case "name_desc":
                    ingredients = ingredients.OrderByDescending(i => i.Name);
                    break;
                case "category":
                    ingredients = ingredients.OrderBy(i => i.Category);
                    break;
                case "category_desc":
                    ingredients = ingredients.OrderByDescending(i => i.Cost);
                    break;
                case "cost":
                    ingredients = ingredients.OrderBy(i => i.Cost);
                    break;
                case "cost_desc":
                    ingredients = ingredients.OrderByDescending(i => i.Cost);
                    break;
                default:
                    ingredients = ingredients.OrderBy(i => i.Name);
                    break;
            }

            return View(ingredients);

        }

        // GET: Ingredients/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Quantity,Cost,Category")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                ingredient.Id = Guid.NewGuid();
                db.Ingredients.Add(ingredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Quantity,Cost,Category")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            db.Ingredients.Remove(ingredient);
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
