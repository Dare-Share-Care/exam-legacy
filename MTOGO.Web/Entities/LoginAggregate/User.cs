namespace MTOGO.Web.Entities.CustomerAggregate;

public class User : BaseEntity
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    
    public long RoleId { get; set; }
    public Role Role { get; set; } = null!;
    
}