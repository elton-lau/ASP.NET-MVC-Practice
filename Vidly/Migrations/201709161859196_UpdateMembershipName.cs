namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipName = 'Monthly' where Id in (5, 6, 7);");
        }
        
        public override void Down()
        {
            Sql("UPDATE MembershipTypes SET MembershipName = NULL where Id in (5, 6, 7);");
        }
    }
}
