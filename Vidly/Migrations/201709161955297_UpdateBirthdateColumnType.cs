namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthdateColumnType : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}
