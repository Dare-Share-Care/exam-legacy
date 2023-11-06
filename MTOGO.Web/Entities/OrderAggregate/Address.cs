namespace MTOGO.Web.Entities.OrderAggregate;

public class Address // ValueObject
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
}