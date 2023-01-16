namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Status", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Status");
        }
    }
}
