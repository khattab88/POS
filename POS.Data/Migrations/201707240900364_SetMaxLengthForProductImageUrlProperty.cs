namespace POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetMaxLengthForProductImageUrlProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ImageUrl", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ImageUrl", c => c.String());
        }
    }
}
