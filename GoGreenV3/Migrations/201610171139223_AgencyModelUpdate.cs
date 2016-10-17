namespace GoGreenV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgencyModelUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Agencies", newName: "AgencyModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AgencyModels", newName: "Agencies");
        }
    }
}
