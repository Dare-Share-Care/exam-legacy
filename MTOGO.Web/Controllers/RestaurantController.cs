using Microsoft.AspNetCore.Mvc;
using MTOGO.Web.Interfaces.DomainServices;
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
                Price = item.Price
            }).ToList()
        };
        
        return Ok(menuViewModel);
    }
}