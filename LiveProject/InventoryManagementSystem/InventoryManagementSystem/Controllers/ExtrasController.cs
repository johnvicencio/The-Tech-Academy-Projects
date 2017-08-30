using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem.DAL;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class ExtrasController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Extras
        public ActionResult Index()
        {
            var extras = db.Extras.Include(e => e.Ingredient);
            return View(extras.ToList());
        }

        // GET: Extras/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extra extra = db.Extras.Find(id);
            if (extra == null)
            {
                return HttpNotFound();
            }
            return View(extra);
        }

        // GET: Extras/Create
        public ActionResult Create()
        {
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name");
            return View();
        }

        // POST: Extras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IngredientId,ExtraId,Name,Cost")] Extra extra)
        {
            if (ModelState.IsValid)
            {
                extra.IngredientId = Guid.NewGuid();
                db.Extras.Add(extra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name", extra.IngredientId);
            return View(extra);
        }

        // GET: Extras/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extra extra = db.Extras.Find(id);
            if (extra == null)
            {
                return HttpNotFound();
            }
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name", extra.IngredientId);
            return View(extra);
        }

        // POST: Extras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IngredientId,ExtraId,Name,Cost")] Extra extra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name", extra.IngredientId);
            return View(extra);
        }

        // GET: Extras/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extra extra = db.Extras.Find(id);
            if (extra == null)
            {
                return HttpNotFound();
            }
            return View(extra);
        }

        // POST: Extras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Extra extra = db.Extras.Find(id);
            db.Extras.Remove(extra);
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
