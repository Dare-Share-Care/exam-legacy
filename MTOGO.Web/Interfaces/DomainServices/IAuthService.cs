using MTOGO.Web.Models.Dto.Auth;

namespace MTOGO.Web.Interfaces.DomainServices;

public interface IAuthService
{
    Task LoginAsync(LoginDto dto);
    Task RegisterAsync(RegisterDto dto);
}