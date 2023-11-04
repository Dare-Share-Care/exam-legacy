using MTOGO.Web.Interfaces;

namespace MTOGO.Web.Entities.RestaurantAggregate;
public class MenuItem : BaseEntity, IAggregateRoot
{
    public string Name { get; set; } = null!;
}