namespace MTOGO.Web.Models.Dto;

public class CreateOrderDto
{
    public List<MenuItemDto>? Items { get; set; } = new();
    public string Email { get; set; } = null!;
    public long RestaurantId { get; set; }
    public AddressDto? DeliveryAddress { get; set; }
}