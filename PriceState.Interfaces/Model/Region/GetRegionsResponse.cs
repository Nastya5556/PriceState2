using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.Region;

public class GetRegionsResponse: IPaginationResponse<RegionModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<RegionModel> Items { get; set; }
}