namespace VADS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        AttendantId = c.Int(nullable: false),
                        Maintenance = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.ScheduleModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ScheduleModels",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleId);
            
            DropTable("dbo.Appointments");
        }
    }
}
