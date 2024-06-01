using DTO.UserDto;
using Microsoft.AspNetCore.Identity;

namespace Service.UserService;

public interface IUserService
{
    Task<List<IdentityUser>> GetUsers();
    Task<IdentityUser?> GetUser(string name);
    Task<IdentityResult> InsertUser(CreateUserDto dto);
}