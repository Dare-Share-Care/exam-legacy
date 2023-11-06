namespace MTOGO.Web.Entities.RestaurantAggregate;

public class Restaurant : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public List<MenuItem> Menu { get; set; } = new();
}