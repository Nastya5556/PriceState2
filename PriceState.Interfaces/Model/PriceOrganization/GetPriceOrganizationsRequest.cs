using PriceState.Interfaces.Model.Organization;
using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.PriceOrganization;

public class GetPriceOrganizationsRequest: IPaginationRequest
{
    public long? OrganizationId { get; set; } = null;
    
    public string Name { get; set; }

    public Page Page { get; set; } = new Page();
}