using Kitchen.Backend.Database;
using Kitchen.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;

namespace Kitchen.Backend.Services;

public class RecipeService
{
    private readonly IDbContextFactory<KitchenDbContext> _dbContextFactory;

    public RecipeService(IDbContextFactory<KitchenDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public List<Recipe> GetRecipes()
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.Recipes.ToList();
    }

    public void AddRecipe(string name)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.Recipes.Add(new Recipe {Name = name});
        context.SaveChanges();
    }

    public void AddStep(long id, Step step)
    {
        using var context = _dbContextFactory.CreateDbContext();
        var recipe = context.Recipes.Single(o => o.Id == id);
        recipe.Directions.Add(step);
        context.SaveChanges();
    }

    public async Task AddImage(long id, IBrowserFile file)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var recipe = context.Recipes.Single(o => o.Id == id);

        if (file != null)
        {
            await using var stream = file.OpenReadStream(file.Size);
            byte[] bytes;
            using (var ms = new MemoryStream())
            {
                await stream.CopyToAsync(ms);
                bytes = ms.ToArray();
            }
            recipe.AddImage(bytes);
            await context.SaveChangesAsync();
        }
    }
}
