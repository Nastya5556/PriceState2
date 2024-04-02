namespace PriseState.Core;

public class AddOrganizationRequest
{
    /// <summary>
    ///     Название кафедры
    /// </summary>
    public string OrganizationName { get; set; } = string.Empty;

    /// <summary>
    ///     Идентификатор факультета
    /// </summary>
    public int RegionId { get; set; }
}