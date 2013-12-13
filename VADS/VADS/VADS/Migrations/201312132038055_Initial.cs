namespace VADS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        NombreCompleto = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.VehicleInfoModels",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        ModelId = c.Int(nullable: false),
                        Year = c.String(nullable: false),
                        Plate = c.String(nullable: false, maxLength: 7),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.VehicleModels", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.OwnerModels", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.ModelId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.VehicleBrands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.VehicleBrands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.OwnerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleStatusModels",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        PidDistance = c.Int(),
                        PidRuntime = c.Int(),
                        PidCoolantTemp = c.Int(),
                        PidSpeed = c.Int(),
                        PidRpm = c.Int(),
                        PidThrottle = c.Int(),
                        PidEngineLoad = c.Int(),
                        PidAbsEngineLoad = c.Int(),
                        PidIntakeTemp = c.Int(),
                        PidIntakePressure = c.Int(),
                        PidMafFlow = c.Int(),
                        PidFuelPressure = c.Int(),
                        PidFuelLevel = c.Int(),
                        PidBarometric = c.Int(),
                        PidTimingAdvance = c.Int(),
                        Time = c.DateTime(nullable: false),
                        VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.StatusId)
                .ForeignKey("dbo.VehicleInfoModels", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.TotoModels",
                c => new
                    {
                        TotoId = c.Int(nullable: false, identity: true),
                        TotoName = c.String(),
                    })
                .PrimaryKey(t => t.TotoId);
            
            CreateTable(
                "dbo.ManteinanceModels",
                c => new
                    {
                        MaintenanceId = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        Detail = c.String(nullable: false),
                        MaintenanceTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaintenanceId)
                .ForeignKey("dbo.VehicleInfoModels", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
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
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Maintenance = c.String(),
                        Date = c.DateTime(nullable: false),
                        Round = c.Int(nullable: false),
                        AttendantId = c.Int(nullable: false),
                        VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.AttendantId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleInfoModels", t => t.VehicleId)
                .Index(t => t.AttendantId)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Appointments", new[] { "VehicleId" });
            DropIndex("dbo.Appointments", new[] { "AttendantId" });
            DropIndex("dbo.EventModels", new[] { "VehicleId" });
            DropIndex("dbo.ManteinanceModels", new[] { "VehicleId" });
            DropIndex("dbo.VehicleStatusModels", new[] { "VehicleId" });
            DropIndex("dbo.VehicleModels", new[] { "BrandId" });
            DropIndex("dbo.VehicleInfoModels", new[] { "OwnerId" });
            DropIndex("dbo.VehicleInfoModels", new[] { "ModelId" });
            DropForeignKey("dbo.Appointments", "VehicleId", "dbo.VehicleInfoModels");
            DropForeignKey("dbo.Appointments", "AttendantId", "dbo.UserProfile");
            DropForeignKey("dbo.EventModels", "VehicleId", "dbo.VehicleInfoModels");
            DropForeignKey("dbo.ManteinanceModels", "VehicleId", "dbo.VehicleInfoModels");
            DropForeignKey("dbo.VehicleStatusModels", "VehicleId", "dbo.VehicleInfoModels");
            DropForeignKey("dbo.VehicleModels", "BrandId", "dbo.VehicleBrands");
            DropForeignKey("dbo.VehicleInfoModels", "OwnerId", "dbo.OwnerModels");
            DropForeignKey("dbo.VehicleInfoModels", "ModelId", "dbo.VehicleModels");
            DropTable("dbo.Appointments");
            DropTable("dbo.EventModels");
            DropTable("dbo.ManteinanceModels");
            DropTable("dbo.TotoModels");
            DropTable("dbo.VehicleStatusModels");
            DropTable("dbo.OwnerModels");
            DropTable("dbo.VehicleBrands");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleInfoModels");
            DropTable("dbo.UserProfile");
        }
    }
}
