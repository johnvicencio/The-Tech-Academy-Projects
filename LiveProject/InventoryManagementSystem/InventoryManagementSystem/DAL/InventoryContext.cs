using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.DAL
{
    public class InventoryContext: DbContext
    {
        public InventoryContext() : base("InventoryContext")
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<SoldItem> SoldItems { get; set; }
        public DbSet<UsedIngredient> UsedIngredients { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        internal Ingredient Ingredient(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public System.Data.Entity.DbSet<InventoryManagementSystem.Models.WeeklyReport> WeeklyReports { get; set; }
    }
}