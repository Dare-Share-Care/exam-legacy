using MTOGO.Web.Entities.CustomerAggregate;

namespace MTOGO.Web.Entities.OrderAggregate;

public class Order : BaseEntity
{
    public List<OrderLine> Lines { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public Address Address { get; set; } = new();
    public long RestaurantId { get; set; }
    public long UserId { get; set; }
    public User User { get; set; } = null!;
}