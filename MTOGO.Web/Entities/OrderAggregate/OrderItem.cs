using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Interfaces;

namespace MTOGO.Web.Entities.OrderAggregate;

public class OrderItem : BaseEntity, IAggregateRoot
{
    public long OrderId {get; set;}
    public long MenUItemId {get; set;}
    public MenuItem MenuItem {get; set;} = null!;
}