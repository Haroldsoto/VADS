namespace VADS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnnecesaryValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleModels", "Model", c => c.String());
            AlterColumn("dbo.VehicleBrands", "Brand", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleBrands", "Brand", c => c.String(nullable: false));
            AlterColumn("dbo.VehicleModels", "Model", c => c.String(nullable: false));
        }
    }
}
