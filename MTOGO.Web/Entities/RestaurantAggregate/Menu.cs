namespace MTOGO.Web.Entities.RestaurantAggregate;

public class Menu : BaseEntity
{
    public List<MenuItem> Items { get; set; } = null!;
    public long RestaurantId { get; set; }
}