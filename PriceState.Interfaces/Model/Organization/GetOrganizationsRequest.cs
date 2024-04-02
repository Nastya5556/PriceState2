using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.Organization;

public class GetOrganizationsRequest: IPaginationRequest
{
    public long? RegionId { get; set; } = null;

    public Page Page { get; set; } = new Page();
}