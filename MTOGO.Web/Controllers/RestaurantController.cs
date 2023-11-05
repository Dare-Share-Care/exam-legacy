using Microsoft.AspNetCore.Mvc;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Models.Dto;

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
    
    [HttpPost("create-restaurant/{restaurantId}")]
    public async Task<IActionResult> CreateRestaurant([FromBody] string name)
    {
        var restaurant = await _restaurantService.CreateRestaurantAsync(name);
        return Ok(restaurant);
    }
    
    [HttpPost("add-menuitem/{restaurantId}")]
    public async Task<IActionResult> AddMenuItem(long restaurantId, [FromBody] MenuItemDto dto)
    {
        var restaurant = await _restaurantService.AddMenuItem(restaurantId, dto);
        return Ok(restaurant);
    }
}