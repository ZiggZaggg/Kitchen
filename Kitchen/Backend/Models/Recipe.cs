using System.ComponentModel.DataAnnotations;
using Kitchen.Backend.Enums;

namespace Kitchen.Backend.Models;

public class Recipe
{
    [Key]
    public long Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public ICollection<Ingredient> Ingredients { get; init; }
    public Cuisine Cuisine { get; init; }
    public ICollection<Step> Instructions { get; init; }
    public byte[] Image { get; private set; }
    public string ImageUrl { get; private set; }

    public void AddImage(byte[] image)
    {
        Image = image;
        ImageUrl = $"data:image/png;base64,{Convert.ToBase64String(image)}";
    }
}
