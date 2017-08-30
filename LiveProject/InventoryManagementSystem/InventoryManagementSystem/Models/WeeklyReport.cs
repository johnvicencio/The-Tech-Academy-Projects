using InventoryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class WeeklyReport
    {
        [Key]
        public DateTime Date { get; set; }
        public virtual IDictionary<Ingredient, int> IngredientsUsed { get; set; }
        public virtual IDictionary<MenuItem, int> ItemsSold { get; set; }
        public double IngredientCost { get; set; }
        public double Income { get; set; }
        public double Profit { get; set; }

        public virtual IList<SoldItem> SoldItems { get; set; }
        public virtual IList<UsedIngredient> UsedIngredients { get; set; }

        public WeeklyReport()
        {
            var db = new InventoryContext();
            IngredientsUsed = Calculations.IngredientsUsedForWeek();
            ItemsSold = new Dictionary<MenuItem, int>();
            foreach (var item in db.MenuItems)
            {
                ItemsSold.Add(item, (int)item.QuantitySold);
            }
            var Totals = Calculations.WeeklyProfit(IngredientsUsed);
            IngredientCost = Totals[0];
            Income = Totals[1];
            Profit = Totals[2];
        }

        public WeeklyReport(IDictionary<Ingredient, int> ingredientsUsed, IList<double> Totals)
        {
            var db = new InventoryContext();
            IngredientsUsed = ingredientsUsed;
            ItemsSold = new Dictionary<MenuItem, int>();
            foreach (var item in db.MenuItems)
            {
                ItemsSold.Add(item, (int)item.QuantitySold);
            };
            IngredientCost = Totals[0];
            Income = Totals[1];
            Profit = Totals[2];
        }
    }
}