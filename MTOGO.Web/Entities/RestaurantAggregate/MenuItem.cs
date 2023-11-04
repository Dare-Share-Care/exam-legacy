namespace MTOGO.Web.Entities.RestaurantAggregate;

public class MenuItem : BaseEntity
{
    public long MenuId { get; set; }
    public Menu Menu { get; set; } = null!;
    public string Name { get; set; } = null!;
    public long PriceId { get; set; }
    public Pricing Pricing { get; set; } = null!;
}