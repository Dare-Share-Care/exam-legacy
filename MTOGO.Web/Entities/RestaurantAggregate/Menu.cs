using MTOGO.Web.Interfaces;

namespace MTOGO.Web.Entities.RestaurantAggregate;

public class Menu : BaseEntity, IAggregateRoot
{
    public List<MenuItem> Items { get; set; } = null!;
    public long RestaurantId { get; set; }
}