namespace PriceState.Interfaces.Model.PriceOrganization;

public class PriceOrganizationModel
{
    public decimal Price { get; set; }
    
    public DateTime Date { get; set; }

    public long ProductId { get; set; }

    public long OrganizationId { get; set; }
}