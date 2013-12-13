using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VADS.Models
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Maintenance { get; set; }


        public DateTime Date { get; set; }

        public int Round { get; set; }


        public int AttendantId { get; set; }
        [ForeignKey("AttendantId")]
        public virtual UserProfile UserProfile { get; set; }


        public int? VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public virtual  VehicleInfoModel VehicleInfoModel { get; set; }
    }
}