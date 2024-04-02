using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.Product;

public class GetProductRequest: IPaginationRequest
{
    public long? ProductId { get; set; } = null;

    public Page Page { get; set; } = new Page();
}