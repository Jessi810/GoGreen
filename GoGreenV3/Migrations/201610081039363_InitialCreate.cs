namespace GoGreenV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(maxLength: 250),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Description = c.String(maxLength: 1000),
                        WebsiteUrl = c.String(),
                        Contact = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Agencies");
        }
    }
}
