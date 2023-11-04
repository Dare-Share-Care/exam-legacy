using MTOGO.Web.Interfaces;

namespace MTOGO.Web.Entities.RestaurantAggregate;

public class Restaurant : BaseEntity, IAggregateRoot
{
    public string Name { get; set; } = null!;
    public Menu Menu { get; set; } = null!;
}