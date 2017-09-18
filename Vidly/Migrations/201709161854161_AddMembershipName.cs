namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String());
            Sql("UPDATE MembershipTypes SET MembershipName = 'Pay as You Go' where Id in (1);");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Monthly' where Id in (2, 3, 4);");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}
