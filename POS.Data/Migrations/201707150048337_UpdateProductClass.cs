namespace POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Code", c => c.String());
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.Products", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "Rating", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImageUrl");
            DropColumn("dbo.Products", "Rating");
            DropColumn("dbo.Products", "ReleaseDate");
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "Code");
        }
    }
}
