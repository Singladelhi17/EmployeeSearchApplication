namespace EmployeeApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "employee_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "EmployeeVM_EmployeeID", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "employee_EmployeeID" });
            DropIndex("dbo.Employees", new[] { "EmployeeVM_EmployeeID" });
            DropColumn("dbo.Employees", "Discriminator");
            DropColumn("dbo.Employees", "employee_EmployeeID");
            DropColumn("dbo.Employees", "EmployeeVM_EmployeeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmployeeVM_EmployeeID", c => c.Int());
            AddColumn("dbo.Employees", "employee_EmployeeID", c => c.Int());
            AddColumn("dbo.Employees", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Employees", "EmployeeVM_EmployeeID");
            CreateIndex("dbo.Employees", "employee_EmployeeID");
            AddForeignKey("dbo.Employees", "EmployeeVM_EmployeeID", "dbo.Employees", "EmployeeID");
            AddForeignKey("dbo.Employees", "employee_EmployeeID", "dbo.Employees", "EmployeeID");
        }
    }
}
