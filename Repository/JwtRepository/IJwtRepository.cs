using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DTO.AuthDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Repository.JwtRepository;

public interface IJwtRepository
{
    AuthSignInResponse CreateToken(Task<IdentityUser> user);
}