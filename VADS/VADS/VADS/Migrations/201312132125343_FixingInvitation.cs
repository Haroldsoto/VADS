namespace VADS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingInvitation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invitations", "UserId", "dbo.UserProfile");
            DropIndex("dbo.Invitations", new[] { "UserId" });
            AddForeignKey("dbo.Invitations", "UserId", "dbo.OwnerModels", "Id", cascadeDelete: true);
            CreateIndex("dbo.Invitations", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Invitations", new[] { "UserId" });
            DropForeignKey("dbo.Invitations", "UserId", "dbo.OwnerModels");
            CreateIndex("dbo.Invitations", "UserId");
            AddForeignKey("dbo.Invitations", "UserId", "dbo.UserProfile", "UserId", cascadeDelete: true);
        }
    }
}
