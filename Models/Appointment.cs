using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auto.Models
{
    public class Appointment
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int GarageID { get; set; }

        [Required]
        public int CarID { get; set; }

        public virtual Garage Service { get; set; }

        public virtual Car Masina { get; set; }

        public virtual ICollection<Part> Piese { get; set; }
    }
}
