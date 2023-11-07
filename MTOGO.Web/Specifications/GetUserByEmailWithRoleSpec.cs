using Ardalis.Specification;
using MTOGO.Web.Entities.CustomerAggregate;

namespace MTOGO.Web.Specifications;

public sealed class GetUserByEmailWithRoleSpec : Specification<User>
{
    public GetUserByEmailWithRoleSpec(string email)
    {
        Query.Where(user => user.Email == email);
        Query.Include(user => user.Role);
    }
}