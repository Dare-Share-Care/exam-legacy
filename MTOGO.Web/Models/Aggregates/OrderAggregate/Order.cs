namespace MTOGO.Web.Models.Aggregates.OrderAggregate;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; }
    public Address Address { get; set; } = new();
}