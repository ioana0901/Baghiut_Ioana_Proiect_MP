using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarInventory.Data;
using CarInventory.Models;

namespace CarInventory.Pages.Cars
{
    public class SearchModel : PageModel
    {
        private readonly CarInventory.Data.CarInventoryContext _context;

        public SearchModel(CarInventory.Data.CarInventoryContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }


        public async Task OnGetAsync()
        {
            var car = from c in _context.Car
                         select c;
            if (!string.IsNullOrEmpty(SearchString))
            {
                car = car.Where(s => s.Name.Contains(SearchString));
            }

            Car = await car.ToListAsync();
        }
    }
   
}
