using MTOGO.Web.Models;

namespace MTOGO.Web.Entities.CustomerAggregate;

public class Role : BaseEntity
{
    public RoleTypes RoleType { get; set; }    
    public List<User> Users { get; set; } = null!;
}