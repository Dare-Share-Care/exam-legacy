namespace MTOGO.Web.Models.Dto;

public class AddressDto
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public int ZipCode { get; set; }
}