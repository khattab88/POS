namespace POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Categories VALUES('Mobiles')");
            Sql("INSERT INTO Categories VALUES('Accessories')");
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
