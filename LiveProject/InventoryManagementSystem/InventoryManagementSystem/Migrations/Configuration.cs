namespace InventoryManagementSystem.Migrations
{
    using InventoryManagementSystem.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InventoryManagementSystem.DAL.InventoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "InventoryManagementSystem.DAL.InventoryContext";
        }

        protected override void Seed(InventoryManagementSystem.DAL.InventoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var Ingredients = new List<Ingredient> { new Ingredient { Name = "Cheese", Quantity = 20, Cost= .25, Category = IngredientType.Dairy},
                new Ingredient {Name = "Ham", Quantity = 15, Cost= 1.00, Category = IngredientType.Protein, },
                new Ingredient {Name = "Lettuce", Quantity = 12, Cost = .25, Category = IngredientType.Produce },
                new Ingredient {Name = "Wheat", Quantity = 24, Cost = .50, Category = IngredientType.Bread } };
            Ingredients.ForEach(s => context.Ingredients.Add(s));
            context.SaveChanges();

            var MenuItems = new List<MenuItem> { new MenuItem { Name = "Ham and Cheese", Price = 9.0,
                IngredientList = new List<Ingredient> {Ingredients.Single(s=> s.Name == "Ham"), Ingredients.Single(s=> s.Name == "Cheese"), Ingredients.Single(s=> s.Name == "Lettuce"), Ingredients.Single(s=> s.Name == "Wheat") } },
                new MenuItem {Name = "Grilled Cheese", Price = 5.0, IngredientList = new List<Ingredient> {Ingredients.Single(s=> s.Name == "Cheese"), Ingredients.Single(s=> s.Name == "Wheat") } } };
            MenuItems.ForEach(s => context.MenuItems.Add(s));
            context.SaveChanges();

            var Extras = new List<Extra> {
                new Extra { Name = "Tomatoes", Cost = .25 },
                new Extra { Name = "Onions", Cost = .35 },
                new Extra { Name = "Olive", Cost = .55 }
            };
            Extras.ForEach(s => context.Extras.Add(s));
            context.SaveChanges();
        }
    }
}
