using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Text;
using DTO.AuthDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Repository.JwtRepository;

public class JwtRepository(IConfiguration configuration) : IJwtRepository
{
    private const int EXPIRATION_MINUTES = int.MaxValue;
    private readonly IConfiguration _configuration = configuration;

  //  private const string KEY = "JQ=F_&?VovVs#9y|K/%>AYh-r%FN'b,zj9:X%a*LIDv6d;L2ls'T!I-:^>c_EK:{TLlEx";
    private const string ISSUER = "webhotel.lan";
    private const string AUDIENCE = "webhotel.lan";
   // private const string SUBJECT = "JWT for webhotel.lan";

    private JwtSecurityToken CreateJwtToken(
        Claim[] claims,
        SigningCredentials credentials,
        DateTime expiration
    ) => new JwtSecurityToken(
        ISSUER,
        AUDIENCE,
        claims,
        expires: expiration,
        signingCredentials: credentials
    );

    private Claim[] CreateClaims(IdentityUser user) => new[]
    {
        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email),
    };

    private SigningCredentials CreateSigningCredentials() => new SigningCredentials(
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
        SecurityAlgorithms.HmacSha256
    );

    public AuthSignInResponse CreateToken(IdentityUser user)
    {
        var expiration = DateTime.UtcNow.AddMinutes(EXPIRATION_MINUTES);
        
        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigningCredentials(),
            expiration
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        return new AuthSignInResponse
        {
            Token = tokenHandler.WriteToken(token),
            Expiration = expiration
        };
    }
}