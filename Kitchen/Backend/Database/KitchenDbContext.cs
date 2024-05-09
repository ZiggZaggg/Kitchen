using Kitchen.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Backend.Database;

public class KitchenDbContext : DbContext
{
    public KitchenDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Location> Locations { get; set; }
}
