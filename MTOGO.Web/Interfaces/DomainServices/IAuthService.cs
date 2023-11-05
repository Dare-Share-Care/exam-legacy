using MTOGO.Web.Models.Dto;

namespace MTOGO.Web.Interfaces.DomainServices;

public interface IAuthService
{
    Task LoginAsync(LoginDto dto);
    Task RegisterAsync(RegisterDto dto);
}