using System.ComponentModel.DataAnnotations;
using Kitchen.Backend.Enums;

namespace Kitchen.Backend.Models;

public class Restaurant
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Cuisine Cuisine { get; set; }
    public Location Location { get; set; }
}
