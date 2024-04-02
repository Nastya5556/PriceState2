namespace PriceState.Data.Models;

public class Unit
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public List<Product> Products { get; set; } = null!;
    
}