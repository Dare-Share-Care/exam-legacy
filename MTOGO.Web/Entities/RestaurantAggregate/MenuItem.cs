using MTOGO.Web.Interfaces;

namespace MTOGO.Web.Entities.RestaurantAggregate;
public class MenuItem : BaseEntity, IAggregateRoot
{
    public long MenuId { get; set; }
    public Menu Menu { get; set; } = null!;
    public string Name { get; set; } = null!;
    public long PriceId { get; set; }
    public Pricing Price { get; set; } = null!;
}