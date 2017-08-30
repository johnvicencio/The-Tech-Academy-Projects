namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIngredientExtraRelashionship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Extra", "Extra_ExtraId", c => c.Guid());
            AddColumn("dbo.Ingredient", "ExtraId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Extra", "Extra_ExtraId");
            CreateIndex("dbo.Ingredient", "ExtraId");
            AddForeignKey("dbo.Extra", "Extra_ExtraId", "dbo.Extra", "ExtraId");
            AddForeignKey("dbo.Ingredient", "ExtraId", "dbo.Extra", "ExtraId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredient", "ExtraId", "dbo.Extra");
            DropForeignKey("dbo.Extra", "Extra_ExtraId", "dbo.Extra");
            DropIndex("dbo.Ingredient", new[] { "ExtraId" });
            DropIndex("dbo.Extra", new[] { "Extra_ExtraId" });
            DropColumn("dbo.Ingredient", "ExtraId");
            DropColumn("dbo.Extra", "Extra_ExtraId");
        }
    }
}
