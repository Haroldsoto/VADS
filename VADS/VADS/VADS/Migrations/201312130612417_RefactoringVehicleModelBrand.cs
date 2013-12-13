namespace VADS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoringVehicleModelBrand : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.VehicleBrands");
            DropTable("dbo.VehicleModels");
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false),
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
                        Brand = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BrandId);
            
            AddColumn("dbo.VehicleInfoModels", "VehicleModelId", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleInfoModels", "VehicleModel_ModelId", c => c.Int());
            AddForeignKey("dbo.VehicleInfoModels", "VehicleModel_ModelId", "dbo.VehicleModels", "ModelId");
            CreateIndex("dbo.VehicleInfoModels", "VehicleModel_ModelId");
            DropColumn("dbo.VehicleInfoModels", "VehicleBrand");
            DropColumn("dbo.VehicleInfoModels", "VehicleModel");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        VehicleModelId = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleModelId);
            
            CreateTable(
                "dbo.VehicleBrands",
                c => new
                    {
                        VehicleBrandId = c.Int(nullable: false, identity: true),
                        BrandId = c.Int(nullable: false),
                        Brand = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleBrandId);
            
            AddColumn("dbo.VehicleInfoModels", "VehicleModel", c => c.String(nullable: false));
            AddColumn("dbo.VehicleInfoModels", "VehicleBrand", c => c.String(nullable: false));
            DropIndex("dbo.VehicleModels", new[] { "BrandId" });
            DropIndex("dbo.VehicleInfoModels", new[] { "VehicleModel_ModelId" });
            DropForeignKey("dbo.VehicleModels", "BrandId", "dbo.VehicleBrands");
            DropForeignKey("dbo.VehicleInfoModels", "VehicleModel_ModelId", "dbo.VehicleModels");
            DropColumn("dbo.VehicleInfoModels", "VehicleModel_ModelId");
            DropColumn("dbo.VehicleInfoModels", "VehicleModelId");
            DropTable("dbo.VehicleBrands");
            DropTable("dbo.VehicleModels");
        }
    }
}
