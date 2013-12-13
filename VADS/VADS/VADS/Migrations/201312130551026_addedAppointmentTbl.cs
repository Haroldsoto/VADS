namespace VADS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAppointmentTbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleInfoModels", "VehicleModel_ModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleModels", "BrandId", "dbo.VehicleBrands");
            DropIndex("dbo.VehicleInfoModels", new[] { "VehicleModel_ModelId" });
            DropIndex("dbo.VehicleModels", new[] { "BrandId" });
            CreateTable(
                "dbo.VehicleBrands",
                c => new
                    {
                        VehicleBrandId = c.Int(nullable: false, identity: true),
                        BrandId = c.Int(nullable: false),
                        Brand = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleBrandId);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        VehicleModelId = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleModelId);
            
            AddColumn("dbo.VehicleInfoModels", "VehicleBrand", c => c.String(nullable: false));
            AddColumn("dbo.VehicleInfoModels", "VehicleModel", c => c.String(nullable: false));
            AddColumn("dbo.Appointments", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "Round", c => c.Int(nullable: false));
            AlterColumn("dbo.Appointments", "VehicleId", c => c.Int());
            AddForeignKey("dbo.Appointments", "AttendantId", "dbo.UserProfile", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "VehicleId", "dbo.VehicleInfoModels", "VehicleId");
            CreateIndex("dbo.Appointments", "AttendantId");
            CreateIndex("dbo.Appointments", "VehicleId");
            DropColumn("dbo.VehicleInfoModels", "VehicleModelId");
            DropColumn("dbo.VehicleInfoModels", "VehicleModel_ModelId");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleBrands");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VehicleBrands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModelId);
            
            AddColumn("dbo.VehicleInfoModels", "VehicleModel_ModelId", c => c.Int());
            AddColumn("dbo.VehicleInfoModels", "VehicleModelId", c => c.Int(nullable: false));
            DropIndex("dbo.Appointments", new[] { "VehicleId" });
            DropIndex("dbo.Appointments", new[] { "AttendantId" });
            DropForeignKey("dbo.Appointments", "VehicleId", "dbo.VehicleInfoModels");
            DropForeignKey("dbo.Appointments", "AttendantId", "dbo.UserProfile");
            AlterColumn("dbo.Appointments", "VehicleId", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "Round");
            DropColumn("dbo.Appointments", "Date");
            DropColumn("dbo.VehicleInfoModels", "VehicleModel");
            DropColumn("dbo.VehicleInfoModels", "VehicleBrand");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleBrands");
            CreateIndex("dbo.VehicleModels", "BrandId");
            CreateIndex("dbo.VehicleInfoModels", "VehicleModel_ModelId");
            AddForeignKey("dbo.VehicleModels", "BrandId", "dbo.VehicleBrands", "BrandId", cascadeDelete: true);
            AddForeignKey("dbo.VehicleInfoModels", "VehicleModel_ModelId", "dbo.VehicleModels", "ModelId");
        }
    }
}
