namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_content_satatus_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "Status", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "Status");
        }
    }
}
