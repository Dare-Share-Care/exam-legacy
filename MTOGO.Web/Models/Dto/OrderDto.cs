namespace MTOGO.Web.Models.Dto;

public class OrderDto : BaseDto
{
public long UserId { get; set; }
    public long RestaurantId { get; set; }
    public DateTime OrderDate { get; set; }
    public AddressDto Address { get; set; } = null!;
    public List<OrderLineDto> Lines { get; set; } = null!;
}