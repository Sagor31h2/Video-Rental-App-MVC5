namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAddIsSubscribedToCustomers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "AddIsSubscribedToCustomer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "AddIsSubscribedToCustomer", c => c.Boolean(nullable: false));
        }
    }
}
