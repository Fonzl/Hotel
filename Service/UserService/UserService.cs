using DTO.UserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryUser;

namespace Service.UserService;

public class UserService(IRepositoryUser userRepository) : IUserService
{
    private readonly IRepositoryUser _userRepository = userRepository;

    public async Task<IdentityUser?> GetUser(string name)
    {
        return await _userRepository.GetUser(name);
    }

    public async Task<List<IdentityUser>> GetUsers()
    {
        return await _userRepository.GetAll();
    }

    public async Task<IdentityResult> InsertUser(CreateUserDto dto)
    {
        return await _userRepository.Insert(dto);
    }
}