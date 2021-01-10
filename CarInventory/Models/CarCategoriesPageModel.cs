using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarInventory.Data;

namespace CarInventory.Models
{
    public class CarCategoriesPageModel : PageModel
    {
        
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(CarInventoryContext context, Car car)
        {
            var allCategories = context.Category;
            var carCategories = new HashSet<int>(
                car.CarCategories.Select(c => c.CarID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = carCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateCarCategories(CarInventoryContext context, string[] selectedCategories, Car carToUpdate)
        {
            if (selectedCategories == null)
            {
                carToUpdate.CarCategories = new List<CarCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var carCategories = new HashSet<int>(
                carToUpdate.CarCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category) 
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if(!carCategories.Contains(cat.ID))
                    {
                        carToUpdate.CarCategories.Add(
                            new CarCategory
                            {
                                CarID = carToUpdate.ID,
                                CategoryID =cat.ID
                            });
                    }
                }
                else
                {
                    if(carCategories.Contains(cat.ID))
                    {
                        CarCategory courseToRemove =
                            carToUpdate
                            .CarCategories
                            .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }

}

