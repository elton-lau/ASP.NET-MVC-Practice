namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixBirthdateColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String());
            DropColumn("dbo.Customers", "Birthdate");
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
