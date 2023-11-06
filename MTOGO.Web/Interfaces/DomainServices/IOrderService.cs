using MTOGO.Web.Models;
using MTOGO.Web.Models.Dto;

namespace MTOGO.Web.Interfaces.DomainServices;

public interface IOrderService
{
    Task<OrderConfirmationModel> CreateOrderAsync(List<MenuItemDto> items, string email);
}