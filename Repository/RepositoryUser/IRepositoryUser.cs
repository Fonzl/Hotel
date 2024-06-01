using DTO.UserDto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryUser
{
    public interface IRepositoryUser
    {
        Task<List<IdentityUser>> GetAll();
        Task<IdentityUser> GetUser(string name);
        Task<IdentityResult> Insert(CreateUserDto dto);
    }
}
