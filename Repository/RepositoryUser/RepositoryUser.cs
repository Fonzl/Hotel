using DTO.UserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryUser
{
    public class RepositoryUser(UserManager<IdentityUser> userManager) : IRepositoryUser
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<List<IdentityUser>> GetAll()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IdentityUser> GetUser(string name)
        {
           var  user = await _userManager.Users.SingleOrDefaultAsync(x => name == x.UserName);
            if (user == null)
            {
                return null;
            }
            return user;
        }

      
        public async Task<IdentityResult> Insert(CreateUserDto dto)
        {
            var newUser = new IdentityUser()
            {
                UserName = dto.UserName,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(newUser, dto.Password);

            return result;
        }
    }
}
