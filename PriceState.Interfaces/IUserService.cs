using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.User;

namespace PriceState.Interfaces;

public interface IUserService
{
    Task<BaseResponse<LoginResponse>> Login(LoginRequest request);

    Task<BaseResponse> Register(RegisterRequest request);

    Task<BaseResponse<TokenResponse>> ActivateAccount(ActivateAccountRequest request);
}
