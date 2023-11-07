using Moq;
using MTOGO.Web.Entities.CustomerAggregate;
using MTOGO.Web.Entities.OrderAggregate;
using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Interfaces.Repositories;
using MTOGO.Web.Services;

namespace MTOGO.Test;

public class OrderServiceTests
{
    private readonly IOrderService _orderService;
    private readonly Mock<IRepository<Order>> _orderRepoMock = new();
    private readonly Mock<IReadRepository<User>> _userReadRepoMock = new();

    private readonly Mock<IReadRepository<Restaurant>> _restaurantReadRepositoryMock = new();

    public OrderServiceTests()
    {
        _orderService = new OrderService
        (
            _orderRepoMock.Object,
            _userReadRepoMock.Object,
            _restaurantReadRepositoryMock.Object
        );
    }

    [Fact]
    public async Task CreateOrderAsync_ShouldCreateOrder()
    {
        //Arrange
        const string email = "testemail@example.com";
        const long restaurantId = 1;
        const string restaurantName = "Restaurant 1";
        const string street = "Street 1";
        const string city = "City 1";
        const int zipCode = 3000;
        const long menuItemId = 1;


        //Act

        //Assert
    }
}