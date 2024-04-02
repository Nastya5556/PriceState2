using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.Product;

public class GetProductsRequest: IPaginationRequest
{
    public string Name { get; set; }

    public Page Page { get; set; } = new Page();
}