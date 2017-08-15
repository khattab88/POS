namespace POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryToProductClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Category_Id", c => c.Int());
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");

            Sql("UPDATE Products SET Category_Id = 1");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropColumn("dbo.Products", "Category_Id");
        }
    }
}
