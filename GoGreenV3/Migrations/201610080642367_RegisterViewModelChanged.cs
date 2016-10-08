namespace GoGreenV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterViewModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MemberSince", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastActive", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "AvatarUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AvatarUrl");
            DropColumn("dbo.AspNetUsers", "LastActive");
            DropColumn("dbo.AspNetUsers", "MemberSince");
        }
    }
}
