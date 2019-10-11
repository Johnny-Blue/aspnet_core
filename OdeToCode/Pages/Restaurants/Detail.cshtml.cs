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
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }

        [TempData]
        public string Message { get; set; }
        private IRestaurantData restaurantData { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int id)
        {
            // var id = HttpContext.Request.Query["Id"];
            Restaurant = restaurantData.GetRestaurantById(id);
            if (Restaurant == null)
            {
                return RedirectToPage("../NotFound");
            }
            return Page();
        }
    }
}
