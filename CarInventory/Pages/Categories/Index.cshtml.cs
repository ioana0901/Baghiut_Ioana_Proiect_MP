using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarInventory.Data;
using CarInventory.Models;

namespace CarInventory.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly CarInventory.Data.CarInventoryContext _context;

        public IndexModel(CarInventory.Data.CarInventoryContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
