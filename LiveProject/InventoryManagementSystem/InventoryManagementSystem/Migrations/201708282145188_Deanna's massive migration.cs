namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deannasmassivemigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.WeeklyReport");
            CreateTable(
                "dbo.SoldItem",
                c => new
                    {
                        Index = c.Guid(nullable: false),
                        ReportDate = c.DateTime(nullable: false),
                        MenuItemId = c.Guid(nullable: false),
                        AmountUsed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Index)
                .ForeignKey("dbo.MenuItem", t => t.MenuItemId, cascadeDelete: true)
                .ForeignKey("dbo.WeeklyReport", t => t.ReportDate, cascadeDelete: true)
                .Index(t => t.ReportDate)
                .Index(t => t.MenuItemId);
            
            CreateTable(
                "dbo.UsedIngredient",
                c => new
                    {
                        Index = c.Guid(nullable: false),
                        ReportDate = c.DateTime(nullable: false),
                        IngredientId = c.Guid(nullable: false),
                        AmountUsed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Index)
                .ForeignKey("dbo.Ingredient", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.WeeklyReport", t => t.ReportDate, cascadeDelete: true)
                .Index(t => t.ReportDate)
                .Index(t => t.IngredientId);
            
            AddColumn("dbo.WeeklyReport", "Date", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.WeeklyReport", "Date");
            DropColumn("dbo.WeeklyReport", "DateOfReport");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WeeklyReport", "DateOfReport", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.UsedIngredient", "ReportDate", "dbo.WeeklyReport");
            DropForeignKey("dbo.UsedIngredient", "IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.SoldItem", "ReportDate", "dbo.WeeklyReport");
            DropForeignKey("dbo.SoldItem", "MenuItemId", "dbo.MenuItem");
            DropIndex("dbo.UsedIngredient", new[] { "IngredientId" });
            DropIndex("dbo.UsedIngredient", new[] { "ReportDate" });
            DropIndex("dbo.SoldItem", new[] { "MenuItemId" });
            DropIndex("dbo.SoldItem", new[] { "ReportDate" });
            DropPrimaryKey("dbo.WeeklyReport");
            DropColumn("dbo.WeeklyReport", "Date");
            DropTable("dbo.UsedIngredient");
            DropTable("dbo.SoldItem");
            AddPrimaryKey("dbo.WeeklyReport", "DateOfReport");
        }
    }
}
