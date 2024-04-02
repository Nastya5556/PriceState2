using PriceState.Interfaces.Model.Organization;
using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.PriceOrganization;

public class GetPriceOrganizationsResponse: IPaginationResponse<PriceOrganizationModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<PriceOrganizationModel> Items { get; set; }
}