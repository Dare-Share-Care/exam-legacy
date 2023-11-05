namespace MTOGO.Web.Models.Dto;

public class MenuItemDto : BaseDto
{
    public string? Name { get; set; }
    public PricingDto Pricing { get; set; }
}