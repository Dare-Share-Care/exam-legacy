using Microsoft.AspNetCore.Mvc;
using MTOGO.Web.Interfaces.DomainServices;

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
    public async Task<IActionResult> GetRestaurantMenu(long restaurantId)
    {
        var menu = await _restaurantService.GetRestaurantMenu(restaurantId);
        return Ok(menu);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] string name)
    {
        var restaurant = await _restaurantService.CreateRestaurantAsync(name);
        return Ok(restaurant);
    }
}