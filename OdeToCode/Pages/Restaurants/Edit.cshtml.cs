using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace MyApp.Namespace
{
    public class EditModel : PageModel
    {
        private IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
        }

        public IActionResult OnGet(int id)
        {
            if (id == -1)
            {
                Restaurant = new Restaurant { Id = id, Cuisine = CuisineType.None };
            }
            else
            {
                Restaurant = restaurantData.GetRestaurantById(id);
                if (Restaurant == null)
                {
                    return RedirectToPage("../NotFound");
                }
            }
            return Page();
        }

        public IActionResult OnPost(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                //save
                Restaurant = restaurantData.SaveRestaurant(restaurant);
                restaurantData.Commit();
                TempData["Message"] = "Saved!";
                return RedirectToPage("./Detail", new { Id = Restaurant.Id });
            }
            return Page();
        }
    }
}
