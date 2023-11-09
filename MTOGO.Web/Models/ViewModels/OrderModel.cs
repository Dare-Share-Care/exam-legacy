namespace MTOGO.Web.Models.ViewModels;

public class OrderModel
{
    public long Id { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderLineModel> Lines { get; set; } = null!;
}