using DTO.AuthDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.JwtRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.JwtRepository;
using Repository.RepositoryCity;

namespace Service.JWT_TokenService
{
    public class jwtService(IJwtRepository jwtRepository) : IjwtService
    {
      
        public Task<AuthSignInResponse> CreateToken(AuthSignInDto user)
        {
            return jwtRepository.CreateToken(user);
        }


    }
}
            
            
