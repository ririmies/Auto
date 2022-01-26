using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auto.Models
{
    public class Part
    {
        public int ID { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        [Range(0, 15000.99)]
        public decimal Price { get; set; }
        [Required]
        public int? AppointmentID { get; set; }

        public virtual Appointment Programare { get; set; }
    }
}
