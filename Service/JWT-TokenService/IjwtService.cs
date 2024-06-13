using DTO.AuthDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.JWT_TokenService
{
    public interface IjwtService
    {
        Task<AuthSignInResponse> CreateToken(AuthSignInDto user);
    }
}
