using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Models
{
    public class RestaurantsContext : DbContext
    {
        public RestaurantsContext(DbContextOptions<RestaurantsContext> options) : base(options) { }

        public DbSet<RestaurantAPI.Models.Ingredient> Ingredient { get; set; }
        public DbSet<RestaurantAPI.Models.DishType> DishType { get; set; }
        public DbSet<RestaurantAPI.Models.Settings> Settings { get; set; }

        public DbSet<RestaurantAPI.Models.User> User { get; set; }
        public DbSet<RestaurantAPI.Models.Dish> Dish { get; set; }
        public DbSet<RestaurantAPI.Models.Order> Order { get; set; }
    }
}