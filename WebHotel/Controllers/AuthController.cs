using DTO.AuthDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.JWT_TokenService;

namespace WebHotel.Controllers
{

    [ApiController]
    [Route("auth")]
    public class AuthController(IjwtService jwtService) : Controller
    {
        // GET: AuthController


        [Route("CreateToken")]
        [HttpPost]
        public async Task<ActionResult<AuthSignInResponse>> CreatToken(AuthSignInDto dto)
        {
            var authData = await jwtService.CreateToken(dto);

            if (authData == null) return Json("Пользователь не найден или введен неверный пароль");
            return Json(authData);
        }
    }
}
