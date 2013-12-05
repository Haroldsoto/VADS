namespace VADS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedUsersandMore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "NombreCompleto", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfile", "NombreCompleto");
        }
    }
}
