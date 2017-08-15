namespace POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmployeeIdColumnInOrderTableToString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropColumn("dbo.Orders", "EmployeeId");
            RenameColumn(table: "dbo.Orders", name: "Employee_Id", newName: "EmployeeId");
            AlterColumn("dbo.Orders", "EmployeeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "EmployeeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            AlterColumn("dbo.Orders", "EmployeeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "EmployeeId", newName: "Employee_Id");
            AddColumn("dbo.Orders", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Employee_Id");
        }
    }
}
