using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auto.Models
{
    public class Car
    {
        public int ID { get; set;}

        [Required]
        [StringLength(20)]
        [RegularExpression (@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Brand { get; set; }
        [Required]
        [StringLength(20)]
        public string Model { get; set; }

        public string FullName { get;set; }
    }

}
