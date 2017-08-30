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
    public class WeeklyReportsController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: WeeklyReports
        public ActionResult Index()
        {
            return View(db.WeeklyReports.ToList());
        }

        // GET: WeeklyReports/Details/5
        public ActionResult Details(long id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DateTime date = new DateTime(id);
            WeeklyReport weeklyReport = db.WeeklyReports.FirstOrDefault(s => s.Date == date);
            if (weeklyReport == null)
            {
                return HttpNotFound();
            }
            return View(weeklyReport);
        }


        // GET: WeeklyReports/Edit/5
        public ActionResult Edit(long id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DateTime date = new DateTime(id);
            WeeklyReport weeklyReport = db.WeeklyReports.FirstOrDefault(s => s.Date == date);
            if (weeklyReport == null)
            {
                return HttpNotFound();
            }
            return View(weeklyReport);
        }

        // POST: WeeklyReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DateOfReport,IngredientCost,Income,Profit")] WeeklyReport weeklyReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weeklyReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weeklyReport);
        }

        // GET: WeeklyReports/Delete/5
        public ActionResult Delete(long id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DateTime date = new DateTime(id);
            WeeklyReport weeklyReport = db.WeeklyReports.FirstOrDefault(s => s.Date == date);
            if (weeklyReport == null)
            {
                return HttpNotFound();
            }
            return View(weeklyReport);
        }

        // POST: WeeklyReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DateTime date = new DateTime(id);
            WeeklyReport weeklyReport = db.WeeklyReports.FirstOrDefault(s => s.Date == date);
            db.WeeklyReports.Remove(weeklyReport);
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
        public ActionResult Create()
        {
            return View(db.MenuItems);
        }
        // POST: Weekly Report

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,QuantitySold")] IEnumerable<MenuItem> MenuItems)
        {
            if (MenuItems != null)
            {
                if (ModelState.IsValid)
                {
                    foreach (var item in MenuItems)
                    {
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Report");
        }

        public ActionResult Report()
        {
            return View(db.Ingredients);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Report([Bind(Include = "Date")]DateTime reportDate)
        {
            IDictionary<Ingredient, int> IngredientsUsed = Calculations.IngredientsUsedForWeek();
            IList<double> WeeklyProfit = Calculations.WeeklyProfit(IngredientsUsed);
            WeeklyReport weeklyReport = new WeeklyReport(IngredientsUsed, WeeklyProfit);
            weeklyReport.Date = reportDate;

            if (ModelState.IsValid)
            {
                db.WeeklyReports.Add(weeklyReport);
                db.SaveChanges();
            }

            foreach (var item in IngredientsUsed)
            {
                UsedIngredient ingredient = new UsedIngredient
                {
                    Index = Guid.NewGuid(),
                    ReportDate = reportDate,
                    Report = db.WeeklyReports.FirstOrDefault(s => s.Date == reportDate),
                    IngredientId = item.Key.Id,
                    Ingredient = db.Ingredients.FirstOrDefault(s => s.Id == item.Key.Id),
                    AmountUsed = item.Value
                };
                if (ModelState.IsValid)
                {
                    db.UsedIngredients.Add(ingredient);
                }
                db.Ingredients.FirstOrDefault(s => s.Id == item.Key.Id).Quantity -= item.Value;
            }

            foreach (var item in db.MenuItems)
            {
                SoldItem sold = new SoldItem
                {
                    ReportDate = reportDate,
                    Report = db.WeeklyReports.FirstOrDefault(s => s.Date == reportDate),
                    MenuItemId = item.ID,
                    MenuItem = db.MenuItems.FirstOrDefault(s => s.ID == item.ID),
                    AmountUsed = (int)item.QuantitySold
                };
                if (ModelState.IsValid)
                {
                    sold.Index = Guid.NewGuid();
                    db.SoldItems.Add(sold);
                }
                item.QuantitySold = 0;

            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
