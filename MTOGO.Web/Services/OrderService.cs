using MTOGO.Web.Entities.OrderAggregate;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Interfaces.Repositories;
using MTOGO.Web.Models;
using MTOGO.Web.Models.Dto;

namespace MTOGO.Web.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> _orderRepository;

    public OrderService(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<OrderConfirmationModel> CreateOrderAsync(List<MenuItemDto> items, string email)
    {
        throw new NotImplementedException();
    }
}