
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DTO.AuthDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace Repository.JwtRepository;

public class JwtRepository(UserManager<IdentityUser> userManager) : IJwtRepository
{
    //private const int EXPIRATION_MINUTES = int.MaxValue;
    //private readonly IConfiguration _configuration = configuration;

    //private const string KEY = "/.]aDuc@{!B'>pZ&cXvnvt*;uD0+}7K7Z^B|bE_>oO]PE_ON[9:DVd=OgPMy";
    //private const string ISSUER = "webhotel.lan";
    //private const string AUDIENCE = "webhotel.la";
    //// private const string SUBJECT = "JWT for webhotel.lan";

    //private JwtSecurityToken CreateJwtToken(IdentityUser user)
    //{
    //    var  claims = new List<Claim> {
    //    new Claim(ClaimTypes.NameIdentifier, user.Id),
    //    new Claim(ClaimTypes.Name, user.UserName),
    //   new Claim(ClaimTypes.Email, user.Email),};

    //    var jwt = new JwtSecurityToken(
    //   issuer:ISSUER,
    //    audience: AUDIENCE,
    //   claims: claims,
    //    expires: DateTime.UtcNow.Add(TimeSpan.FromDays(7)),
    //    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY)), SecurityAlgorithms.HmacSha256)); ; ; ; ;
    //return jwt;
    //}
    ////private Claim[] CreateClaims(IdentityUser user) => new[]
    ////{
    ////    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
    ////    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    ////    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
    ////    new Claim(ClaimTypes.NameIdentifier, user.Id),
    ////    new Claim(ClaimTypes.Name, user.UserName),
    ////    new Claim(ClaimTypes.Email, user.Email),
    ////};

    ////private SigningCredentials CreateSigningCredentials() => new SigningCredentials(
    ////    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
    ////    SecurityAlgorithms.HmacSha256
    ////);

    //public AuthSignInResponse CreateToken(IdentityUser user)
    //{
    //    var expiration = DateTime.UtcNow.Add(TimeSpan.FromDays(7));
        
    //    var token = CreateJwtToken(user);

    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    Console.WriteLine(tokenHandler.WriteToken(token));
    //    Console.WriteLine(expiration);
    //    return new AuthSignInResponse
    //    {
            
    //        Token = tokenHandler.WriteToken(token),
    //        Expiration = expiration
    //    };
    //}
    
    private const int EXPIRATION_MINUTES = 60;

    private const string KEY = "8b0fa5c39bcc9d22a9d4c8d42ba40fd73c85488b4c43d74b1b26122fe4301700";
    private const string ISSUER = "bookapilan";
    private const string AUDIENCE = "bookapilan";
    private const string SUBJECT = "JWT for bookapi.lan";

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
        new Claim(JwtRegisteredClaimNames.Sub, SUBJECT),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email),
    };

    private SigningCredentials CreateSigningCredentials() => new SigningCredentials(
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY)),
        SecurityAlgorithms.HmacSha256
    );

    public async Task<AuthSignInResponse> CreateToken(AuthSignInDto dto)
    {
        var user = await userManager.FindByNameAsync(dto.UserName);
        if (user == null) return null;

        var isValidPassword = await userManager.CheckPasswordAsync(user, dto.Password);

        if (!isValidPassword) return null;

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