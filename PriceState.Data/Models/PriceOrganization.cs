namespace PriceState.Data.Models;

public class PriceOrganization
{

    
    public decimal Price { get; set; }
    
    public DateTime Date { get; set; }
    
    public Product Product { get; set; }

    public long ProductId { get; set; }
    
    public Organization Organization { get; set; }

    public long OrganizationId { get; set; }
    
    
}