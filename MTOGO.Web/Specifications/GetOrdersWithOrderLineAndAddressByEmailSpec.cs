using Ardalis.Specification;
using MTOGO.Web.Entities.OrderAggregate;

namespace MTOGO.Web.Specifications;

public sealed class GetOrdersWithOrderLineAndAddressByEmailSpec : Specification<Order>
{
    public GetOrdersWithOrderLineAndAddressByEmailSpec(string email)
    {
        Query.Where(order => order.User.Email == email);
        Query.Include(order => order.Lines)
            .ThenInclude(line => line.MenuItem);
        Query.Include(order => order.Address);
    }
}