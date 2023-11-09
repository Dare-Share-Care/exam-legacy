using MTOGO.Web.Models.Dto.Auth;

namespace MTOGO.Web.Interfaces.DomainServices;

public interface IAuthService
{
    Task<string> LoginAsync(LoginDto dto);
    Task RegisterCustomerAsync(RegisterDto dto);
    
    Task ChangePasswordAsync(ChangePasswordDto dto);
}