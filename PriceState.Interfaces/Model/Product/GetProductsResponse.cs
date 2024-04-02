using PriceState.Interfaces.Model.PriceOrganization;
using PriceState.Interfaces.Pagination;

namespace PriceState.Interfaces.Model.Product;

public class GetProductsResponse: IPaginationResponse<ProductModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<ProductModel> Items { get; set; }
}