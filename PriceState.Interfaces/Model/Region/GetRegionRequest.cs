using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.Region;

public class GetRegionRequest: IPaginationRequest
{
    public long? RegionId { get; set; } = null;

    public Page Page { get; set; } = new Page();
}