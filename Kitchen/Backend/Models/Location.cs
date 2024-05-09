using System.ComponentModel.DataAnnotations;

namespace Kitchen.Backend.Models;

public class Location
{
    [Key]
    public long Id { get; set; }
}
