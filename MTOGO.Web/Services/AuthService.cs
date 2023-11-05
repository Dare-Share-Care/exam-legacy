using MTOGO.Web.Entities.CustomerAggregate;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Interfaces.Repositories;
using MTOGO.Web.Models.Dto;

namespace MTOGO.Web.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _userRepository;

    public AuthService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<string> LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        //Validate that email is not already in use
        var users = await _userRepository.ListAsync();

        if (users.Any(x => x.Email == dto.Email))
            throw new Exception("Email already exists");

        //Map dto to user and hash password
        var user = new User
        {
            Email = dto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            RoleId = (int)dto.RoleType
        };
        
        //Add user to database
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
    }
}