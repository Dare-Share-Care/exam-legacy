using Moq;
using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Interfaces.Repositories;
using MTOGO.Web.Services;

namespace MTOGO.Test;

public class RestaurantServiceTests
{
    private readonly IRestaurantService _restaurantService;
    private readonly Mock<IReadRepository<Restaurant>> _readRepoMock = new Mock<IReadRepository<Restaurant>>();
    private readonly Mock<IRepository<Restaurant>> _repoMock = new Mock<IRepository<Restaurant>>();

    public RestaurantServiceTests()
    {
        _restaurantService = new RestaurantService(_readRepoMock.Object, _repoMock.Object);
    }
    
    [Fact]
    public void GetAllRestaurantsAsync()
    {
    }
}