using DTO.AuthDto;
using DTO.UserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.JwtRepository;
using Service.UserService;
using Service.JWT_TokenService;
using WebHotel;
using Microsoft.AspNetCore.Authorization;


namespace BookAppAPI.Controllers;

[ApiController]
[Route("users")]
public class UserController(IUserService userService, IjwtService jwtService, UserManager<IdentityUser> userManager) : Controller
{
    private readonly UserManager<IdentityUser> _userManager = userManager;

   // [Authorize]
    [HttpGet]
    public async Task<JsonResult> GetUsers()
    {
        var users = await userService.GetUsers();
        return Json(users);
    }
   // [Authorize]
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

    [Route("CreateToken")]
    [HttpPost]
    public async Task<ActionResult<AuthSignInResponse>> CreatToken(AuthSignInDto authSignInDto)
    {
       
        if (!ModelState.IsValid)
        {
            return BadRequest("Bad credentials");
        } 
        var user = await _userManager.FindByNameAsync(authSignInDto.UserName);
        if (user == null)
        {
            return BadRequest("Bad credentials");
        }
        var isPasswordValid = await _userManager.CheckPasswordAsync(user, authSignInDto.Password);

        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }
        var token = jwtService.CreateToken(user);
        return Ok(token);
    }
    //[Authorize]
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<BodyType>>> GetBodyTypes()
    //{
    //    return await _context.BodyTypes.ToListAsync();
    //}
    //[HttpPost("/token")]
    //public IActionResult Token(string username, string password)
    //{
    //    var identity = GetIdentity(username, password);
    //    if (identity == null)
    //    {
    //        return BadRequest(new { errorText = "Invalid username or password." });
    //    }

    //    var now = DateTime.UtcNow;
    //    // создаем JWT-токен
    //    var jwt = new JwtSecurityToken(
    //            issuer: AuthOptions.ISSUER,
    //            audience: AuthOptions.AUDIENCE,
    //            notBefore: now,
    //            claims: identity.Claims,
    //            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
    //            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
    //    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

    //    var response = new
    //    {
    //        access_token = encodedJwt,
    //        username = identity.Name
    //    };

    //    return Json(response);
    //}

    //private ClaimsIdentity GetIdentity(string username, string password)
    //{
    //    var persons = userService.GetUsers;
    //    var person = persons.ToString(x => x.Name == username && x.password == password);
    //    if (person != null)
    //    {
    //        var claims = new List<Claim>
    //            {
    //                new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
    //                new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
    //            };
    //        ClaimsIdentity claimsIdentity =
    //        new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
    //            ClaimsIdentity.DefaultRoleClaimType);
    //        return claimsIdentity;
    //    }

    //    // если пользователя не найдено
    //    return null;
    //}
}