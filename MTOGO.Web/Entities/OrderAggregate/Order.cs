using MTOGO.Web.Interfaces;

namespace MTOGO.Web.Entities.OrderAggregate;

public class Order : BaseEntity, IAggregateRoot
{
    public DateTime OrderDate { get; set; }
    public Address Address { get; set; } = new();
}