using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VADS.Models
{
    public class Invitation
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("UserId")]
        public virtual OwnerModel OwnerModel { get; set; }
        public int UserId { get; set; }

    }
}