using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Models.Dto;

namespace MTOGO.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "Customer")]
    public async Task<IActionResult> CreateOrderAsync(CreateOrderDto dto)
    {
        var orderConfirmation = await _orderService.CreateOrderAsync(dto);
        return Ok(orderConfirmation);
    }

    [HttpGet("get-orders-by-email")]
    public async Task<IActionResult> GetOrdersByEmailAsync(string email)
    {
        var orders = await _orderService.GetOrdersByEmailAsync(email);
        return Ok(orders);
    }
}