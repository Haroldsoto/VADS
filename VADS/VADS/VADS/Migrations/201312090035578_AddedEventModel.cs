namespace VADS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEventModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventModels",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Type = c.String(),
                        Time = c.DateTime(nullable: false),
                        VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.VehicleInfoModels", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.EventModels", new[] { "VehicleId" });
            DropForeignKey("dbo.EventModels", "VehicleId", "dbo.VehicleInfoModels");
            DropTable("dbo.EventModels");
        }
    }
}
