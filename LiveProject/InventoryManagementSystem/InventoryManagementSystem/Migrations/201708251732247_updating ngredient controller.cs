namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingngredientcontroller : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredient", "ExtraId", "dbo.Extra");
            DropIndex("dbo.Ingredient", new[] { "ExtraId" });
            AddColumn("dbo.Extra", "Ingredient_Id", c => c.Guid());
            CreateIndex("dbo.Extra", "Ingredient_Id");
            AddForeignKey("dbo.Extra", "Ingredient_Id", "dbo.Ingredient", "Id");
            DropColumn("dbo.Ingredient", "ExtraId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredient", "ExtraId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Extra", "Ingredient_Id", "dbo.Ingredient");
            DropIndex("dbo.Extra", new[] { "Ingredient_Id" });
            DropColumn("dbo.Extra", "Ingredient_Id");
            CreateIndex("dbo.Ingredient", "ExtraId");
            AddForeignKey("dbo.Ingredient", "ExtraId", "dbo.Extra", "ExtraId", cascadeDelete: true);
        }
    }
}
