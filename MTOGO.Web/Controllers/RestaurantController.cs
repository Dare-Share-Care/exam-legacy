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


    [HttpGet("get-all-restaurants")]
    public async Task<IActionResult> GetAllRestaurants()
    {
        var restaurants = await _restaurantService.GetAllRestaurantsAsync();
        return Ok(restaurants);
    }

    [HttpGet("{restaurantId}/menu")]
    public async Task<IActionResult> GetRestaurantMenu(long restaurantId)
    {
        var menu = await _restaurantService.GetRestaurantMenuAsync(restaurantId);
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
        var restaurant = await _restaurantService.AddMenuItemAsync(restaurantId, dto);
        return Ok(restaurant);
    }

    [HttpDelete("remove-menuitem/{restaurantId}")]
    public async Task<IActionResult> RemoveMenuItem(long restaurantId, [FromBody] long menuItemId)
    {
        var restaurant = await _restaurantService.RemoveMenuItemAsync(restaurantId, menuItemId);
        return Ok(restaurant);
    }
}