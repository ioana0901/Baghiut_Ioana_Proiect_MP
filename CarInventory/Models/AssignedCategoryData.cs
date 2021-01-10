using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarInventory.Models
{
    public class AssignedCategoryData
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}
