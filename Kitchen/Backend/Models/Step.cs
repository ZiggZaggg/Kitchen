using Microsoft.EntityFrameworkCore;

namespace Kitchen.Backend.Models;

[Owned]
public class Step
{
    public int Number { get; init; }
    public string Description { get; init; }
}
