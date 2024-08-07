using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Backend.Models;

[Owned]
public class Instruction
{
    [Key]
    public long Id { get; set; }
    public int Number { get; set; }
    public string Description { get; set; }
}
