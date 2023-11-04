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
    public async Task<IActionResult> GetMenu(long restaurantId)
    {
        var menu = await _restaurantService.GetMenu(restaurantId);
        return Ok(menu);
    }
}