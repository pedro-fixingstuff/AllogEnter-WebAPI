namespace Univali.Api.Models;

public class AddressDto
{
    public int Id {get; set;}
    public string Street {get; set;} = string.Empty;
    public int Number {get; set;}
    public string AdditionalInfo {get; set;} = string.Empty;
    public string Neighborhood {get; set;} = string.Empty;
    public string City {get; set;} = string.Empty;
    public string Zip {get; set;} = string.Empty;
}