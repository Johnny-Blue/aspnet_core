using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace MyApp.Namespace
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SrchRest { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        private IConfiguration configuration { get; }

        private IRestaurantData restaurantData { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            this.configuration = configuration;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            Message = configuration["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SrchRest);
        }
    }
}
