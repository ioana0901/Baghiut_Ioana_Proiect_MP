using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInventory.Models
{
    public class CarData
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<CarCategory> CarCategories{get;set;}
    }
}
