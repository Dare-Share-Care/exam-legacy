namespace MTOGO.Web.Entities.OrderAggregate;

public class Address // ValueObject
{
    public long Id { get; set; }
    public string Street { get; set; } = null!;
    public string City { get; private set; } = null!;
    public string ZipCode { get; private set; } = null!;
    public string Country { get; private set; } = null!;
}