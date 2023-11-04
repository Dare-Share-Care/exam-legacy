namespace MTOGO.Web.Entities.OrderAggregate;

public class Order : BaseEntity
{
    public List<OrderLine> Lines { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public Address Address { get; set; } = new();
}