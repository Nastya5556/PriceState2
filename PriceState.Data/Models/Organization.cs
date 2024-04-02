namespace PriceState.Data.Models;

public class Organization
{
    public long Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public Region Region { get; set; }

    public int RegionId { get; set; }
    public List<PriceOrganization> PriceOrganizations { get; set; } = null!;
}