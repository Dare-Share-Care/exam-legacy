namespace MTOGO.Web.Models.Dto;

public class RegisterDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public RoleTypes RoleType { get; set; }
}