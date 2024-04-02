using PriceState.Data.Enums;

namespace PriceState.Interfaces.Model.User;

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string SureName { get; set; } = string.Empty;
    public EnumUserRole Role { get; set; }
    public long Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public int RegionId { get; set; }
}