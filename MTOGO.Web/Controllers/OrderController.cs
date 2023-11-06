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
    public async Task<IActionResult> CreateOrderAsync(CreateOrderDto dto)
    {
        var orderConfirmation = await _orderService.CreateOrderAsync(dto);
        return Ok(orderConfirmation);
    }
}