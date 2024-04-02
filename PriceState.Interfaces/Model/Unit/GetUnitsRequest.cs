using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.Unit;

public class GetUnitsRequest: IPaginationRequest
{
    public Page Page { get; set; } = new Page();
}