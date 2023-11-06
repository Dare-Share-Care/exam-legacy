using MTOGO.Web.Entities.OrderAggregate;

namespace MTOGO.Web.Models;

public class OrderConfirmationModel
{
    public long OrderNumber { get; set; }
    public string? RestaurantName { get; set; }
    public string? RestaurantAddress { get; set; }
    public string? RestaurantPhoneNumber { get; set; }
    public string? Message { get; set; }
    public DateTime EstimatedDelivery { get; set; }
    public List<OrderLine>? Order { get; set; }
    public decimal Total { get; set; }
}