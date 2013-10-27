//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Data.Linq.Mapping;

//namespace VADS.Models
//{
//    public class VehicleBrandsContext : DbContext
//    {
//        public VehicleBrandsContext()
//            : base("DefaultConnection")
//        {
//        }
//        public DbSet<VehicleBrands> VehicleBrandses { get; set; }
//        public DbSet<VehicleModels> VehicleModelses { get; set; }
//    }

//    public class VehicleBrands
//    {
//        [Key]
//        public int VehicleBrandId { get; set; }
//        [Required]
//        [DataType(DataType.Text)]
//        public string Brand { get; set; }
//    }
//    public class VehicleModels 
//    {
//        [Key]
//        public int VehicleModelId { get; set; }
//        [Required]
//        [DataType(DataType.Text)]
//        public string Model { get; set; }
//        public int VehicleBrandId { get; set; }
//        [ForeignKey("VehicleBrandId")]
//        public virtual VehicleBrands VehicleBrands { get; set; }
//    }

//}