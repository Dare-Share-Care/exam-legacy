using Microsoft.AspNetCore.Mvc;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Models.Dto;
using MTOGO.Web.Models.ViewModels;

namespace MTOGO.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpGet("{restaurantId}/menu")]
    public async Task<IActionResult> GetMenu(long restaurantId)
    {
        var dto = await _restaurantService.GetMenu(restaurantId);

        var menuViewModel = new MenuViewModel
        {
            Items = dto.Items.Select(item => new MenuItemViewModel
            {
                Name = item.Name,
                Price = item.Pricing.Price
            }).ToList()
        };

        return Ok(menuViewModel);
    }

    
    [HttpPost("{restaurantId}/menu")]
    public async Task<IActionResult> CreateMenu(long restaurantId, MenuDto menuDto)
    {
        var dto = await _restaurantService.CreateMenu(restaurantId, menuDto);
        return Ok(dto);
    }
    
    
    
    
    
}   