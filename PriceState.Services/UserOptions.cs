﻿using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PriceState.Services;

public static class UserOptions
{
    public const string ISSUER = "Yaroslav"; // издатель токена

    public const string AUDIENCE = "Yaroslav2"; // потребитель токена

    private const string KEY = "mysupersecret_secretkey!123"; // ключ для шифрации

    public const int LIFETIME = 10000; // время жизни токена - 1 минута

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}