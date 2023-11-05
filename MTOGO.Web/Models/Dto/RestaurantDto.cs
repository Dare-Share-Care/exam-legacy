namespace MTOGO.Web.Models.Dto;

public class RestaurantDto : BaseDto
{
    public string? Name { get; set; }
    public List<MenuItemDto> Menu { get; set; } = new();    
}