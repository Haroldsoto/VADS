using System;

namespace VADS.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public int VehicleId { get; set; }
        public int AttendantId { get; set; }
    }
}