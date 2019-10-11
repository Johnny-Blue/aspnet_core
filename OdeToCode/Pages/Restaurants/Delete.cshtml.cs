using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace MyApp.Namespace
{
    public class DeleteModel : PageModel
    {
        public Restaurant Restaurant { get; set; }

        [TempData]
        public string Message { get; set; }

        private IRestaurantData _restaurantData;
        public DeleteModel(IRestaurantData restaurantData)
        {
            this._restaurantData = restaurantData;
        }

        public IActionResult OnGet(int id)
        {
            Restaurant = _restaurantData.GetRestaurantById(id);
            if (Restaurant == null)
            {
                RedirectToPage("../NotFound");
            }
            return Page();
        }

        public void OnPost(int id)
        {
            Restaurant = _restaurantData.GetRestaurantById(id);
            if (Restaurant == null)
            {
                RedirectToPage("../NotFound");
            }

            TempData["Message"] = Restaurant.Name + " deleted.";
            Restaurant = _restaurantData.DeleteRestaurant(id);
            _restaurantData.Commit();

        }
    }
}
