namespace PriceState.Data.Models;

public class Region
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public List<Organization> Organizations { get; set; } = null!;
    public List<User> Users { get; set; } = null!;
}