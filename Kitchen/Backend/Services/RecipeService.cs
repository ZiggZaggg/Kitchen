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

    public void AddInstruction(long id, Step instruction)
    {
        using var context = _dbContextFactory.CreateDbContext();
        var recipe = context.Recipes.Single(o => o.Id == id);
        recipe.Instructions.Add(instruction);
        context.SaveChanges();
    }

    public void DeleteInstruction(long id, Step instruction)
    {
        using var context = _dbContextFactory.CreateDbContext();
        var recipe = context.Recipes.Single(o => o.Id == id);
        var instructionToRemove = recipe.Instructions.FirstOrDefault(o => o.Description == instruction.Description);

        if (instructionToRemove != null)
        {
            recipe.Instructions.Remove(instructionToRemove);
        }
        context.SaveChanges();
    }

    public void SaveInstructions()
    {

    }

    public void DeleteRecipe(long id)
    {
        using var context = _dbContextFactory.CreateDbContext();
        var recipeToRemove = context.Recipes.Single(o => o.Id == id);

        if (recipeToRemove != null)
        {
            context.Recipes.Remove(recipeToRemove);
        }
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
