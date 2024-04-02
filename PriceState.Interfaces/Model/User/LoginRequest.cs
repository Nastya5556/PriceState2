using System.ComponentModel.DataAnnotations;

namespace PriceState.Interfaces.Model.User;

public class LoginRequest
{
    /// <summary>
    /// Почта
    /// </summary>
    [Required]
    public string Email { get; set; } = null!;

    /// <summary>
    /// Пароль
    /// </summary>
    [Required]
    public string Password { get; set; } = null!;
}