using MTOGO.Web.Models.ViewModels;
using MTOGO.Web.Models.Dto;

namespace MTOGO.Web.Interfaces.DomainServices;

public interface IOrderService
{
    Task<OrderConfirmationModel> CreateOrderAsync(CreateOrderDto dto);
    Task<List<OrderModel>> GetOrdersByEmailAsync(string email);
}