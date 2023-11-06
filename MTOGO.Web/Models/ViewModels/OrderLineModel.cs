namespace MTOGO.Web.Models.ViewModels;

public class OrderLineModel
{
    public string MenuItemName { get; set; } = null!;
    public decimal MenuItemPrice { get; set; }
    public int Quantity { get; set; }
}