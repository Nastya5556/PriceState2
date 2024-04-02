namespace PriseState.Core.Models;

public class AddRegionRequest
{
    public string Name { get; set; } = string.Empty;
    
    public int RegionId { get; set; }
}