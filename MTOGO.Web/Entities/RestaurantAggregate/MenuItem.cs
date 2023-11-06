using System.Text.Json.Serialization;

namespace MTOGO.Web.Entities.RestaurantAggregate;

public class MenuItem : BaseEntity
{
    public long RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}