using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurantList;
        public InMemoryRestaurantData()
        {
            _restaurantList = new List<Restaurant>
            {
                new Restaurant {Id=1, Name = "Grand Pizza", Location="Galati", Cuisine = CuisineType.Italian},
                new Restaurant {Id=2, Name = "Jolly Bean", Location="Aartselaar", Cuisine = CuisineType.Mexican},
                new Restaurant {Id=3, Name = "Bollywood", Location="Bombay", Cuisine = CuisineType.Indian}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return _restaurantList.Where(r => r.Name.IndexOf(name ?? "") >= 0).OrderBy(r => r.Name).Select(r => r);
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _restaurantList.Where(r => r.Id == id).FirstOrDefault();
        }

        public Restaurant SaveRestaurant(Restaurant restaurant)
        {
            if (restaurant.Id == -1)
            {
                var nextId = _restaurantList.Max(r => r.Id) + 1;
                _restaurantList.Add(new Restaurant { Id = nextId, Cuisine = restaurant.Cuisine, Location = restaurant.Location, Name = restaurant.Name });
                return _restaurantList.SingleOrDefault(r => r.Id == nextId);
            }
            else
            {
                var rstrnt = _restaurantList.SingleOrDefault(r => r.Id == restaurant.Id);

                if (rstrnt == null)
                {
                    return null;
                }

                rstrnt.Cuisine = restaurant.Cuisine;
                rstrnt.Name = restaurant.Name;
                rstrnt.Location = restaurant.Location;

                return rstrnt;
            }
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restDel = _restaurantList.Where(r => r.Id == id).FirstOrDefault();
            if (restDel != null)
            {
                _restaurantList.Remove(restDel);
            }
            return restDel;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
