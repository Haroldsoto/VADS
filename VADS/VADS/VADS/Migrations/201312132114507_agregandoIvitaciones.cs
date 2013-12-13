namespace VADS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandoIvitaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Invitations", new[] { "UserId" });
            DropForeignKey("dbo.Invitations", "UserId", "dbo.UserProfile");
            DropTable("dbo.Invitations");
        }
    }
}
