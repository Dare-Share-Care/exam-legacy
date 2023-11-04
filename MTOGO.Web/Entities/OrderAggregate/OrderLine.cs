using MTOGO.Web.Entities.RestaurantAggregate;

namespace MTOGO.Web.Entities.OrderAggregate;

public class OrderLine : BaseEntity
{
    public long OrderId {get; set;}
    public long MenuItemId {get; set;}
    public Order Order {get; set;} = null!;
    public MenuItem MenuItem {get; set;} = null!;
}