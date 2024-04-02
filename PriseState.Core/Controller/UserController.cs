using Microsoft.AspNetCore.Mvc;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.User;


namespace PriseState.Core.Controller;

public class UserController: Microsoft.AspNetCore.Mvc.Controller
{
    [HttpPost]
    [Route($"{nameof(Login)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<LoginResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    public async Task<BaseResponse<LoginResponse>> Login([FromServices] IUserService auth, [FromBody] LoginRequest request)
    {
        return await auth.Login(request);
    }

    [HttpPut]
    [Route($"{nameof(Register)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    public async Task<BaseResponse> Register([FromServices] IUserService auth, [FromBody] RegisterRequest request)
    {
        return await auth.Register(request);
    }

    [HttpPatch]
    [Route($"{nameof(ActivateAccount)}")]
    [ProducesResponseType(200, Type = typeof(BaseResponse<TokenResponse>))]
    [ProducesResponseType(400, Type = typeof(BaseResponse))]
    public async Task<BaseResponse> ActivateAccount([FromServices] IUserService auth, [FromBody] ActivateAccountRequest request)
    {
        return await auth.ActivateAccount(request);
    }
}