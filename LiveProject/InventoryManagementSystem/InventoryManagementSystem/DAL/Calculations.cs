using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.DAL
{
    public class Calculations
    {
        public static IDictionary<Ingredient, int> IngredientsUsedForWeek()
        {
            InventoryContext db = new InventoryContext();
            var _menuItems = db.MenuItems;
            IDictionary<Ingredient, int> _ingredientsUsed = new Dictionary<Ingredient, int>();
            foreach (var item in _menuItems)
            {
                IngredientsForMenuItem(item, _ingredientsUsed);
            }
            return _ingredientsUsed;
        }

        public static IList<double> WeeklyProfit(IDictionary<Ingredient, int> _ingredientsUsed)
        {
            double WeekCost = CostofWeeklyIngredients(_ingredientsUsed);
            double WeekIncome = WeeklyIncome();
            double WeekProfit = WeekIncome - WeekCost;

            IList<double> WeekStats = new List<double> { WeekCost, WeekIncome, WeekProfit };
            return WeekStats;
        }

        private static void IngredientsForMenuItem(MenuItem _menuItem, IDictionary<Ingredient, int> ingredientsUsed)
        {
            if (_menuItem.QuantitySold != null)
            {
                foreach (var ingredient in _menuItem.IngredientList)
                {
                    if (ingredientsUsed.ContainsKey(ingredient))
                    {
                        ingredientsUsed[ingredient] += (int)_menuItem.QuantitySold;
                    }
                    else
                    {
                        ingredientsUsed.Add(ingredient, (int)_menuItem.QuantitySold);
                    }
                }
            }
        }

        private static double CostofWeeklyIngredients(IDictionary<Ingredient, int> _ingredientsUsed)
        {
            InventoryContext db = new InventoryContext();
            double Cost = 0.0;
            foreach (var item in _ingredientsUsed)
            {
                var itemId = item.Key.Id;
                Ingredient _ingredient = db.Ingredients.FirstOrDefault(s => s.Id == itemId);
                Cost += (_ingredient.Cost * item.Value);
            }
            return Cost;
        }

        private static double WeeklyIncome()
        {
            InventoryContext db = new InventoryContext();
            double Income = 0.0;
            var _menuItems = db.MenuItems;
            foreach (var item in _menuItems)
            {
                Income += (item.Price * (double)item.QuantitySold);
            }
            return Income;
        }
    }
}