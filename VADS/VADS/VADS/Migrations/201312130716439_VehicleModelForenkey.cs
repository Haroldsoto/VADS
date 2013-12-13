namespace VADS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleModelForenkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleInfoModels", "VehicleModel_ModelId", "dbo.VehicleModels");
            DropIndex("dbo.VehicleInfoModels", new[] { "VehicleModel_ModelId" });
            RenameColumn(table: "dbo.VehicleInfoModels", name: "VehicleModel_ModelId", newName: "ModelId");
            AddForeignKey("dbo.VehicleInfoModels", "ModelId", "dbo.VehicleModels", "ModelId", cascadeDelete: true);
            CreateIndex("dbo.VehicleInfoModels", "ModelId");
            DropColumn("dbo.VehicleInfoModels", "VehicleModelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleInfoModels", "VehicleModelId", c => c.Int(nullable: false));
            DropIndex("dbo.VehicleInfoModels", new[] { "ModelId" });
            DropForeignKey("dbo.VehicleInfoModels", "ModelId", "dbo.VehicleModels");
            RenameColumn(table: "dbo.VehicleInfoModels", name: "ModelId", newName: "VehicleModel_ModelId");
            CreateIndex("dbo.VehicleInfoModels", "VehicleModel_ModelId");
            AddForeignKey("dbo.VehicleInfoModels", "VehicleModel_ModelId", "dbo.VehicleModels", "ModelId");
        }
    }
}
