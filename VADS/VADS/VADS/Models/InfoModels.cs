using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;

namespace VADS.Models
{
    public class ScheduleModel
    {
        [Key]
        public int ScheduleId { get; set; }
        public DateTime Date { get; set; }
    }

    public class TotoModel
    {
        [Key]
        public int TotoId { get; set; }
        public string TotoName { get; set; }
    }

    public class VehicleInfoModel
    {
        [Key]
        public int VehicleId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Vehicle Brand")]
        public string VehicleBrand { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Vehicle Model")]
        public string VehicleModel { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        [StringLength(7,ErrorMessage = "Placa incorrecta.", MinimumLength = 7)]
        public string Plate { get; set; }
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        [Display(Name = "Client")]
        public virtual OwnerModel OwnerModel { get; set; }
    }
    public class VehicleBrands
    {
        [Key]
        public int VehicleBrandId { get; set; }
        public int BrandId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Brand { get; set; }
    }
    public class VehicleModels
    {
        [Key]
        public int VehicleModelId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Model { get; set; }
        public int BrandId { get; set; }
    }

    public class OwnerModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        //[RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "eMail is not in proper format")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }

    public class VehicleStatusModel
    {
        [Key]
        public int? StatusId { get; set; }        
        public int? PidDistance { get; set; }
        public int? PidRuntime { get; set; }
        public int? PidCoolantTemp { get; set; }
        public int? PidSpeed { get; set; }
        public int? PidRpm { get; set; }
        public int? PidThrottle { get; set; }
        public int? PidEngineLoad { get; set; }
        public int? PidAbsEngineLoad { get; set; }
        public int? PidIntakeTemp { get; set; }
        public int? PidIntakePressure { get; set; }
        public int? PidMafFlow { get; set; }
        public int? PidFuelPressure { get; set; }
        public int? PidFuelLevel { get; set; }
        public int? PidBarometric { get; set; }
        public int? PidTimingAdvance { get; set; }
        public DateTime Time { get; set; }
        public int? VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public virtual VehicleInfoModel VehicleInfo { get; set; }
    }

    public class ManteinanceModel
    {
        [Key]
        public int MaintenanceId { get; set; }
        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public virtual VehicleInfoModel VehicleInfo { get; set; }
        [DataType(DataType.Text)]
        [Required]
        public string Detail { get; set; }
        [Required]
        public DateTime MaintenanceTime { get; set; }
    }
}