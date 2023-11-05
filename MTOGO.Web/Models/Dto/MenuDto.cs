namespace MTOGO.Web.Models.Dto;

public class MenuDto : BaseDto
{
    public List<MenuItemDto> Items { get; set; } = new();
}