namespace PriceState.Interfaces.Pagination;

public class Page
{
    public int? Skip { get; set; } = 0;

    /// <summary>
    ///     Вытащить
    /// </summary>
    public int? Take { get; set; } = 10;
}