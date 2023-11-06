using MTOGO.Web.Entities.CustomerAggregate;
using MTOGO.Web.Entities.OrderAggregate;
using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Interfaces.Repositories;
using MTOGO.Web.Models.Dto;
using MTOGO.Web.Models.ViewModels;
using MTOGO.Web.Specifications;

namespace MTOGO.Web.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> _orderRepository;
    private readonly IReadRepository<User> _userReadRepository;
    private readonly IReadRepository<Restaurant> _restaurantReadRepository;

    public OrderService(IRepository<Order> orderRepository, IReadRepository<User> userReadRepository,
        IReadRepository<Restaurant> restaurantReadRepository)
    {
        _orderRepository = orderRepository;
        _userReadRepository = userReadRepository;
        _restaurantReadRepository = restaurantReadRepository;
    }

    public async Task<OrderConfirmationModel> CreateOrderAsync(CreateOrderDto dto)
    {
        var user = await _userReadRepository.FirstOrDefaultAsync(new GetUserByEmailSpec(dto.Email));
        var restaurant =
            await _restaurantReadRepository.FirstOrDefaultAsync(new GetRestaurantWithMenuItemsSpec(dto.RestaurantId));

        if (user == null)
            throw new Exception("User not found");

        if (restaurant == null)
            throw new Exception("Restaurant not found");


        //Create order
        var order = new Order
        {
            UserId = user.Id,
            Lines = new List<OrderLine>(),
            RestaurantId = restaurant.Id,
            OrderDate = DateTime.Now,
            Address = new Address
            {
                Street = dto.DeliveryAddress.Street,
                City = dto.DeliveryAddress.City,
                ZipCode = dto.DeliveryAddress.ZipCode
            }
        };

        //Filter items that belong to the specified restaurant
        var itemsFromRestaurant = dto.Items.Where(item => restaurant.Menu.Any(menuItem => menuItem.Id == item.Id));

        //Count the number of each menu item
        var itemQuantities = new Dictionary<long, int>();

        foreach (var item in itemsFromRestaurant)
        {
            if (!itemQuantities.ContainsKey(item.Id))
            {
                itemQuantities[item.Id] = 1;
            }
            else
            {
                itemQuantities[item.Id]++;
            }
        }

        //Add order lines
        foreach (var itemId in itemQuantities.Keys)
        {
            order.Lines.Add(new OrderLine
            {
                MenuItemId = itemId,
                Quantity = itemQuantities[itemId],
                Price = dto.Items.Find(i => i.Id == itemId)?.Price ?? 0
            });
        }

        // Save order to database
        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync();


        //Create order confirmation view model
        var orderLines = (from line in order.Lines
            let menuItem = restaurant.Menu.Find(m => m.Id == line.MenuItemId)
            select new OrderLineModel
            {
                MenuItemName = menuItem.Name,
                MenuItemPrice = menuItem.Price,
                Quantity = line.Quantity
            }).ToList();

        return new OrderConfirmationModel
        {
            OrderNumber = order.Id,
            RestaurantName = restaurant.Name,
            RestaurantAddress = restaurant.Address,
            RestaurantPhoneNumber = restaurant.PhoneNumber,
            Message = "Your order has been received and is being processed",
            EstimatedDelivery = DateTime.Now.AddMinutes(15),
            OrderLines = orderLines,
            Total = order.Lines.Sum(l => l.Price * l.Quantity)
        };
    }
}