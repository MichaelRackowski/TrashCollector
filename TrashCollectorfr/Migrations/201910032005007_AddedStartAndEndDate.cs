namespace TrashCollectorfr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStartAndEndDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "StartDay", c => c.String());
            AddColumn("dbo.Customers", "EndDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "EndDay");
            DropColumn("dbo.Customers", "StartDay");
        }
    }
}
