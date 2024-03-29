using Ardalis.Specification;
using MTOGO.Web.Entities.CustomerAggregate;

namespace MTOGO.Web.Specifications;

public sealed class GetUserByEmailSpec : Specification<User>
{
    public GetUserByEmailSpec(string email)
    {
        Query.Where(user => user.Email == email);
    }
}