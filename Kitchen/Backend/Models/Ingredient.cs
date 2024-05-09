using System.ComponentModel.DataAnnotations;

namespace Kitchen.Backend.Models;

public class Ingredient
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
}
