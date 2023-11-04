using MTOGO.Web.Interfaces;

namespace MTOGO.Web.Entities.RestaurantAggregate;

public class Pricing : BaseEntity, IAggregateRoot
{
    public decimal Price { get; set; }
}