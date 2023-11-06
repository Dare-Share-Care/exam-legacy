using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MTOGO.Web.Entities.CustomerAggregate;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Interfaces.Repositories;
using MTOGO.Web.Models.Dto.Auth;
using MTOGO.Web.Specifications;

namespace MTOGO.Web.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _userRepository;

    public AuthService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.FirstOrDefaultAsync(new GetUserByEmailSpec(dto.Email));

        // validate
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            throw new Exception("Username or password is incorrect");

        var token = CreateToken(user);
        
        return token;
    }

    public async Task RegisterCustomerAsync(RegisterDto dto)
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
            RoleId = 1 //Customer
        };

        //Add user to database
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, "Customer")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: cred
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}