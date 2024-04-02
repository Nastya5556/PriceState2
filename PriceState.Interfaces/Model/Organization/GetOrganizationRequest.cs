using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.Organization;

public class GetOrganizationRequest: IPaginationRequest
{
    public long? OrganizationId { get; set; } = null;

    public Page Page { get; set; } = new Page();
}