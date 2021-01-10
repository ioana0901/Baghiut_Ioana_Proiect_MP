using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarInventory.Data;
using CarInventory.Models;

namespace CarInventory.Pages.Manufacturers
{
    public class IndexModel : PageModel
    {
        private readonly CarInventory.Data.CarInventoryContext _context;

        public IndexModel(CarInventory.Data.CarInventoryContext context)
        {
            _context = context;
        }

        public IList<Manufacturer> Manufacturer { get;set; }

        public async Task OnGetAsync()
        {
            Manufacturer = await _context.Manufacturer.ToListAsync();
        }
    }
}
