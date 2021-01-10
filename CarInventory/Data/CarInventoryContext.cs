using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarInventory.Models;

namespace CarInventory.Data
{
    public class CarInventoryContext : DbContext
    {
        public CarInventoryContext (DbContextOptions<CarInventoryContext> options)
            : base(options)
        {
        }

        public DbSet<CarInventory.Models.Car> Car { get; set; }
        public DbSet<CarInventory.Models.Manufacturer> Manufacturer { get; set; }
        public DbSet<CarInventory.Models.Category> Category { get; set; }

        public DbSet<CarInventory.Models.CarCategory> CarCategory { get; set; }

        
    }
}
