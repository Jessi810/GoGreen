namespace GoGreenV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarkerModelChanged2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MarkerModels", "Location", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MarkerModels", "Location", c => c.String());
        }
    }
}
