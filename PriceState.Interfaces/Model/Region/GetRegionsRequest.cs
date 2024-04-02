using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.Region;

public class GetRegionsRequest: IPaginationRequest
{
    public Page Page { get; set; } = new Page();
}