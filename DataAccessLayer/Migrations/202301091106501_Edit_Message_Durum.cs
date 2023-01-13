namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_Message_Durum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Situation", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Situation");
        }
    }
}
