using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.Organization;

public class GetOrganizationsResponse: IPaginationResponse<OrganizationModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<OrganizationModel> Items { get; set; }
}