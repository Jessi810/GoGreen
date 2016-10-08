namespace GoGreenV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarkerModelChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MarkerModels", "Description", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MarkerModels", "Description", c => c.String());
        }
    }
}
