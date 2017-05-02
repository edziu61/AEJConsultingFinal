namespace AEJConsulting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Company_Name = c.String(),
                        Contact_Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Employee_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        PO_Number = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Customer_CustomerID = c.Int(),
                        Employee_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customer", t => t.Customer_CustomerID)
                .ForeignKey("dbo.Employee", t => t.Employee_EmployeeID)
                .Index(t => t.Customer_CustomerID)
                .Index(t => t.Employee_EmployeeID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        PTO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        Description = c.String(),
                        Available = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "Employee_EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Order", "Customer_CustomerID", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.Order", new[] { "Customer_CustomerID" });
            DropTable("dbo.Product");
            DropTable("dbo.Employee");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
