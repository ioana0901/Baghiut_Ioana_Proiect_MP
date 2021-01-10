using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarInventory.Data;
using CarInventory.Models;


namespace CarInventory.Pages.Cars
{
    public class CreateModel : CarCategoriesPageModel
    {
        private readonly CarInventory.Data.CarInventoryContext _context;

        public CreateModel(CarInventory.Data.CarInventoryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ManufacturerID"] = new SelectList(_context.Set<Manufacturer>(), "ID", "ManufacturerName");
            var car = new Car();
            car.CarCategories = new List<CarCategory>();
            PopulateAssignedCategoryData(_context, car);
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCar = new Car();
            if (selectedCategories != null)
            {
                newCar.CarCategories = new List<CarCategory>();
                foreach(var cat in selectedCategories)
                {
                    var catToAdd = new CarCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newCar.CarCategories.Add(catToAdd);
                }
            }
            if(await TryUpdateModelAsync<Car>(
                newCar,
                "Car",
                i => i.Name, i => i.Details, i => i.Quantity, i => i.CarYear, i => i.Price, i=>i.ManufacturerID))
            {
                _context.Car.Add(newCar);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newCar);
            return Page();
        }
    }
}
