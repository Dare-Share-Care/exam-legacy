using MTOGO.Web.Models.Dto;

namespace MTOGO.Web.Interfaces.DomainServices;

public interface IAuthService
{
    Task<string> LoginAsync(string username, string password);
    Task RegisterAsync(RegisterDto dto);
}