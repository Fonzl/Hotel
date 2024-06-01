using DTO.AuthDto;
using DTO.UserDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repository.JwtRepository;
using Service.UserService;
using System.IdentityModel.Tokens.Jwt;
using WebHotel;


namespace BookAppAPI.Controllers;

[ApiController]
[Route("users")]
public class UserController(IUserService userService, IJwtRepository jwtRepository) : Controller
{
    
    

    [HttpGet]
    public async Task<JsonResult> GetUsers()
    {
        var users = await userService.GetUsers();
        return Json(users);
    }
    [Route ("{username}")]
    [HttpGet]
    public async Task<JsonResult?> GetUser(string username)
    {
        var user = await userService.GetUser(username);
        return Json(user);
    }
    [Route("create")]
    [HttpPost]
    public async Task<JsonResult> CreateUser(CreateUserDto dto)
    {
        var result = await userService.InsertUser(dto);

        return Json(result);
    }

    //[Route("CreateToken")]
    //[HttpPost]
    //public async Task<JsonResult?> CreatToken(AuthSignInDto authSignInDto)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return null;
    //    }
    //    var user = userService.GetUser(authSignInDto.UserName);
    //    if (user == null)
    //    {
    //        return null;
    //    }
    //    var token = jwtRepository.CreateToken(user);
    //    return Json(token);
    //}
    [HttpPost("/token")]
    public IActionResult Token(string username, string password)
    {
        var identity = GetIdentity(username, password);
        if (identity == null)
        {
            return BadRequest(new { errorText = "Invalid username or password." });
        }

        var now = DateTime.UtcNow;
        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var response = new
        {
            access_token = encodedJwt,
            username = identity.Name
        };

        return Json(response);
    }

}