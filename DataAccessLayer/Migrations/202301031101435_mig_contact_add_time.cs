namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contact_add_time : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "DateTimee", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "DateTimee");
        }
    }
}
