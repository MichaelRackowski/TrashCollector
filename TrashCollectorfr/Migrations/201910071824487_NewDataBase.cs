namespace TrashCollectorfr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDataBase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "StartDay", c => c.DateTime());
            AlterColumn("dbo.Customers", "EndDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "EndDay", c => c.String());
            AlterColumn("dbo.Customers", "StartDay", c => c.String());
        }
    }
}
