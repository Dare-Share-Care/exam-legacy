using Ardalis.Specification;
using Moq;
using MTOGO.Web.Entities.RestaurantAggregate;
using MTOGO.Web.Exceptions;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Interfaces.Repositories;
using MTOGO.Web.Models.Dto;
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
    public async Task GetAllRestaurantsAsync_ShouldReturnAllRestaurants()
    {
        //Arrange
        var restaurantsResult = new List<Restaurant>
        {
            new Restaurant { Id = 1, Name = "Restaurant 1" },
            new Restaurant { Id = 2, Name = "Restaurant 2" },
            new Restaurant { Id = 3, Name = "Restaurant 3" }
        };

        //Setup the mock to return the restaurants
        _readRepoMock.Setup(x => x.ListAsync(new CancellationToken()))
            .ReturnsAsync(restaurantsResult);

        //Act
        var restaurantsFound = await _restaurantService.GetAllRestaurantsAsync();

        //Assert

        //Contains 3 restaurants
        Assert.Equal(3, restaurantsFound.Count);

        //Contains the correct restaurants
        Assert.Equal("Restaurant 1", restaurantsFound[0].Name);
        Assert.Equal("Restaurant 2", restaurantsFound[1].Name);
        Assert.Equal("Restaurant 3", restaurantsFound[2].Name);
    }

    [Fact]
    public async Task CreateRestaurantAsync_ShouldCreateRestaurant()
    {
        //Arrange
        const string restaurantName = "Restaurant 1";
        var restaurant = new Restaurant { Id = 1, Name = restaurantName };

        //Setup the mock to return the restaurant
        _repoMock.Setup(x => x.AddAsync(It.IsAny<Restaurant>(), new CancellationToken()))
            .ReturnsAsync(restaurant);

        //Act
        var restaurantCreated = await _restaurantService.CreateRestaurantAsync(restaurantName);

        //Assert
        Assert.Equal(restaurantName, restaurantCreated.Name);
    }

    [Fact]
    public async Task GetRestaurantMenuAsync_ShouldReturnMenu()
    {
        //Arrange
        var restaurantId = 1;
        var restaurant = new Restaurant
        {
            Id = restaurantId, Name = "Restaurant 1", MenuItems =
            {
                new MenuItem { Id = 1, Name = "MenuItem 1", Price = 10 },
                new MenuItem { Id = 2, Name = "MenuItem 2", Price = 20 },
                new MenuItem { Id = 3, Name = "MenuItem 3", Price = 30 }
            }
        };

        //Setup the mock to return the restaurant
        _readRepoMock.Setup(x => x.FirstOrDefaultAsync(It.IsAny<ISpecification<Restaurant>>(), new CancellationToken()))
            .ReturnsAsync(restaurant);

        //Act
        var menu = await _restaurantService.GetRestaurantMenuAsync(restaurantId);

        //Assert

        //Contains 3 menu items
        Assert.Equal(3, menu.Count);

        //Contains the correct menu items
        Assert.Equal("MenuItem 1", menu[0].Name);
        Assert.Equal("MenuItem 2", menu[1].Name);
        Assert.Equal("MenuItem 3", menu[2].Name);
    }

    [Fact]
    public async Task AddMenuItemAsync_ShouldUpdateRestaurantWithNewMenuItem()
    {
        //Arrange
        const long restaurantId = 1;
        const string menuItemName = "MenuItem 1";
        const decimal menuItemPrice = 10;

        var restaurant = new Restaurant {Id = restaurantId, Name = "Restaurant 1", MenuItems =
        {
            new MenuItem {Id = 1, Name = "MenuItem 1", Price = 10},
            new MenuItem {Id = 2, Name = "MenuItem 2", Price = 20},
            new MenuItem {Id = 3, Name = "MenuItem 3", Price = 30}
        }};

        var menuItemDto = new MenuItemDto { Name = menuItemName, Price = menuItemPrice };

        //Setup the mock to return the restaurant
        _repoMock.Setup(x => x.FirstOrDefaultAsync(It.IsAny<ISpecification<Restaurant>>(), new CancellationToken()))
            .ReturnsAsync(restaurant);
        
        //Act
        var restaurantDto = await _restaurantService.AddMenuItemAsync(restaurantId, menuItemDto);

        //Assert
        
        //Contains the correct restaurant id
        Assert.Equal(restaurantId, restaurantDto.Id);

        // Contains 4 menu items
        Assert.Equal(4, restaurantDto.Menu.Count);

        // Contains the correct menu items
        Assert.Equal("MenuItem 1", restaurantDto.Menu[0].Name);
        Assert.Equal("MenuItem 2", restaurantDto.Menu[1].Name);
        Assert.Equal("MenuItem 3", restaurantDto.Menu[2].Name);
        Assert.Equal("MenuItem 1", restaurantDto.Menu[3].Name);
    }

    [Fact]
    public async Task AddMenuItemAsync_ShouldThrowRestaurantException_WhenRestaurantNotFound()
    {
        //Arrange
        const long restaurantId = 1;
        var menuItemDto = new MenuItemDto {Name = "MenuItem 1", Price = 10};
    
        _repoMock.Setup(x => x.FirstOrDefaultAsync(It.IsAny<ISpecification<Restaurant>>(), new CancellationToken()))
            .ReturnsAsync((Restaurant) null);
    
        //Act & Assert
        await Assert.ThrowsAsync<RestaurantException>(() => _restaurantService.AddMenuItemAsync(restaurantId, menuItemDto));
    }
    
    [Fact]
    public async Task RemoveMenuItemAsync_ShouldUpdateRestaurantWithRemovedMenuItem()
    {
        //Arrange
        const long restaurantId = 1;
        const long menuItemId = 1;
    
        var restaurant = new Restaurant {Id = restaurantId, Name = "Restaurant 1", MenuItems =
        {
            new MenuItem {Id = 1, Name = "MenuItem 1", Price = 10},
            new MenuItem {Id = 2, Name = "MenuItem 2", Price = 20},
            new MenuItem {Id = 3, Name = "MenuItem 3", Price = 30}
        }};
    
        //Setup the mock to return the restaurant
        _repoMock.Setup(x => x.FirstOrDefaultAsync(It.IsAny<ISpecification<Restaurant>>(), new CancellationToken()))
            .ReturnsAsync(restaurant);
    
        //Act
        var restaurantDto = await _restaurantService.RemoveMenuItemAsync(restaurantId, menuItemId);
    
        //Assert
    
        //Contains the correct restaurant id
        Assert.Equal(restaurantId, restaurantDto.Id);
    
        // Contains 2 menu items
        Assert.Equal(2, restaurantDto.Menu.Count);
    
        // Contains the correct menu items
        Assert.Equal("MenuItem 2", restaurantDto.Menu[0].Name);
        Assert.Equal("MenuItem 3", restaurantDto.Menu[1].Name);
    }
    
    [Fact]
    public async Task RemoveMenuItemAsync_ShouldThrowRestaurantException_WhenRestaurantNotFound()
    {
        //Arrange
        const long restaurantId = 1;
        const long menuItemId = 1;
    
        _repoMock.Setup(x => x.FirstOrDefaultAsync(It.IsAny<ISpecification<Restaurant>>(), new CancellationToken()))
            .ReturnsAsync((Restaurant) null);
    
        //Act & Assert
        await Assert.ThrowsAsync<RestaurantException>(() => _restaurantService.RemoveMenuItemAsync(restaurantId, menuItemId));
    }
}