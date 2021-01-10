using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInventory.Models
{
    public class Manufacturer
    {
        public int ID { get; set; }
        [Display(Name = "Manufacturer")]
        public string ManufacturerName { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
