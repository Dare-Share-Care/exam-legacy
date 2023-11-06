using MTOGO.Web.Models.ViewModels;

namespace MTOGO.Web.Models.ViewModels;

public class OrderConfirmationModel
{
    public long OrderNumber { get; set; }
    public string? RestaurantName { get; set; }
    public string? RestaurantAddress { get; set; }
    public string? RestaurantPhoneNumber { get; set; }
    public string? Message { get; set; }
    public DateTime EstimatedDelivery { get; set; }
    public List<OrderLineModel>? OrderLines { get; set; }
    public decimal Total { get; set; }
}