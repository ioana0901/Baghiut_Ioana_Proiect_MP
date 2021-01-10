using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarInventory.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Display(Name="Car")]
        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]/////
        public string Details { get; set; }

        [Display(Name="Stock")]
        public string Quantity { get; set; }

        [Range(1950,2020)]
        [Display(Name = "Year")]
        public int CarYear { get; set; }
        public int ManufacturerID { get; set; }

      
        public Manufacturer Manufacturer { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [Display(Name="Category")]
        public ICollection<CarCategory> CarCategories { get; set; }
    }
}
