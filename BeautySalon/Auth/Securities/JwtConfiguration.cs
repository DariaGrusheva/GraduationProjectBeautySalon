﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BeautySalon.Auth.Securities
{
    public class JwtConfiguration
    {
        public required string Key { get; init; }
        public required string Issuer { get; init; }
        public required string Audience { get; init; }

        internal SymmetricSecurityKey GetSigningKey() => new(Encoding.UTF8.GetBytes(Key));
    }
}
