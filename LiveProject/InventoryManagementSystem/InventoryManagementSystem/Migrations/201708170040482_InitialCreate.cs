namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuItem",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuItemIngredient",
                c => new
                    {
                        MenuItem_ID = c.Guid(nullable: false),
                        Ingredient_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuItem_ID, t.Ingredient_Id })
                .ForeignKey("dbo.MenuItem", t => t.MenuItem_ID, cascadeDelete: true)
                .ForeignKey("dbo.Ingredient", t => t.Ingredient_Id, cascadeDelete: true)
                .Index(t => t.MenuItem_ID)
                .Index(t => t.Ingredient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItemIngredient", "Ingredient_Id", "dbo.Ingredient");
            DropForeignKey("dbo.MenuItemIngredient", "MenuItem_ID", "dbo.MenuItem");
            DropIndex("dbo.MenuItemIngredient", new[] { "Ingredient_Id" });
            DropIndex("dbo.MenuItemIngredient", new[] { "MenuItem_ID" });
            DropTable("dbo.MenuItemIngredient");
            DropTable("dbo.MenuItem");
            DropTable("dbo.Ingredient");
        }
    }
}
