using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static InventoryManagementSystem.Models.Ingredient;

namespace InventoryManagementSystem.DAL
{
    public class InventoryInitializer : System.Data.Entity.DropCreateDatabaseAlways<InventoryContext>
    {
        protected override void Seed(InventoryContext context)
        {
            var Ingredients = new List<Ingredient> { new Ingredient { Name = "Cheese", Quantity = 20, Cost= .25, Category = IngredientType.Dairy},
                new Ingredient {Name = "Ham", Quantity = 15, Cost= 1.0, Category = IngredientType.Protein },
                new Ingredient {Name = "Lettuce", Quantity = 12, Cost = .25, Category = IngredientType.Produce },
                new Ingredient {Name = "Wheat", Quantity = 24, Cost = .50, Category = IngredientType.Bread } };
            Ingredients.ForEach(s => context.Ingredients.Add(s));
            context.SaveChanges();

            var MenuItems = new List<MenuItem> { new MenuItem { Name = "Ham and Cheese", Price = 9.0,
                IngredientList = new List<Ingredient> {Ingredients.Single(s=> s.Name == "Ham"), Ingredients.Single(s=> s.Name == "Cheese"), Ingredients.Single(s=> s.Name == "Lettuce"), Ingredients.Single(s=> s.Name == "Wheat") } },
                new MenuItem {Name = "Grilled Cheese", Price = 5.0, IngredientList = new List<Ingredient> {Ingredients.Single(s=> s.Name == "Cheese"), Ingredients.Single(s=> s.Name == "Wheat") } } };
            MenuItems.ForEach(s => context.MenuItems.Add(s));
            context.SaveChanges();
        }
    }
}