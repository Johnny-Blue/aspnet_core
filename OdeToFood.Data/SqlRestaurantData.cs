using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        OdeToFoodDbContext _dbContext;
        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _dbContext = context;
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return _dbContext.Restaurants.Where(r => r.Name.IndexOf(name ?? "") >= 0).OrderBy(r => r.Name).Select(r => r);
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _dbContext.Restaurants.Where(r => r.Id == id).FirstOrDefault();
        }

        public Restaurant SaveRestaurant(Restaurant restaurant)
        {
            if (restaurant.Id == -1)
            {
                Restaurant newRestaurant = new Restaurant { Cuisine = restaurant.Cuisine, Location = restaurant.Location, Name = restaurant.Name };
                _dbContext.Restaurants.Add(newRestaurant);
                return newRestaurant;
            }
            else
            {
                var rstrnt = _dbContext.Restaurants.Attach(restaurant);
                rstrnt.State = EntityState.Modified;
                return restaurant;
            }
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restDel = _dbContext.Restaurants.Where(r => r.Id == id).FirstOrDefault();
            if (restDel != null)
            {
                _dbContext.Restaurants.Remove(restDel);
            }
            return restDel;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }
}
