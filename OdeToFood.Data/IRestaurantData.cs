using System;
using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);

        Restaurant GetRestaurantById(int id);

        Restaurant SaveRestaurant(Restaurant restaurant);

        Restaurant DeleteRestaurant(int id);

        int Commit();
    }
}
