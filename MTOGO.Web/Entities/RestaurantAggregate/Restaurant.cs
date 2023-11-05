namespace MTOGO.Web.Entities.RestaurantAggregate;

public class Restaurant : BaseEntity
{
    public string Name { get; set; } = null!;
    public List<MenuItem> MenuItems { get; set; } = new();
}