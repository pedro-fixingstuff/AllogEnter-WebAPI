using Microsoft.AspNetCore.Mvc;
using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Controllers;

[ApiController]
[Route("api/customers/{customerId}/addresses")]
public class AddressesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<AddressDto>> GetAddresses(int customerId)
    {
        var customerFromDatabase = Data.Instance.Customers.FirstOrDefault(customer => customer.Id == customerId);

        if (customerFromDatabase == null) return NotFound();

        var addresssesToReturn = new List<AddressDto>();

        foreach (var address in customerFromDatabase.Addresses)
        {
            addresssesToReturn.Add(new AddressDto
            {
                Id = address.Id,
                Street = address.Street,
                Number = address.Number,
                AdditionalInfo = address.AdditionalInfo,
                Neighborhood = address.Neighborhood,
                City = address.City,
                Zip = address.Zip
            });
        }

        return Ok(addresssesToReturn);
    }

    [HttpGet("{addressId}")]
    public ActionResult<AddressDto> GetAddress(int customerId, int addressId)
    {
        var addressFromDatabase = Data.Instance.Customers.FirstOrDefault(customer => customer.Id == customerId)
            ?.Addresses.FirstOrDefault(address => address.Id == addressId);

        if (addressFromDatabase == null) return NotFound();

        var addressToReturn = new AddressDto
        {
            Id = addressFromDatabase.Id,
            Street = addressFromDatabase.Street,
            Number = addressFromDatabase.Number,
            AdditionalInfo = addressFromDatabase.AdditionalInfo,
            Neighborhood = addressFromDatabase.Neighborhood,
            City = addressFromDatabase.City,
            Zip = addressFromDatabase.Zip
        };
        return Ok(addressToReturn);
    }

    [HttpPost]
    public ActionResult<AddressDto> CreateAddress(int customerId, AddressForCreationDto addressForCreationDto)
    {
        var customerForAddressCreation = Data.Instance.Customers.FirstOrDefault(customer => customer.Id == customerId);

        if (customerForAddressCreation == null) return NotFound();

        var addressEntity = new Address
        {
            Id = Data.Instance.Customers.SelectMany(c => c.Addresses).Max(a => a.Id) + 1,
            Street = addressForCreationDto.Street,
            Number = addressForCreationDto.Number,
            AdditionalInfo = addressForCreationDto.AdditionalInfo,
            Neighborhood = addressForCreationDto.Neighborhood,
            City = addressForCreationDto.City,
            Zip = addressForCreationDto.Zip
        };

        customerForAddressCreation.Addresses.Add(addressEntity);

        var addressToReturn = new AddressDto
        {
            Id = addressEntity.Id,
            Street = addressEntity.Street,
            Number = addressEntity.Number,
            AdditionalInfo = addressEntity.AdditionalInfo,
            Neighborhood = addressEntity.Neighborhood,
            City = addressEntity.City,
            Zip = addressEntity.Zip
        };

        return CreatedAtRoute
        (
            "GetAddress",
            new
            {
                customerId = customerForAddressCreation.Id,
                addressId = addressToReturn.Id
            },
            addressToReturn
        );
    }

    [HttpPut("{addressId}")]
    public ActionResult UpdateAddress(int customerId, int addressId, AddressForUpdateDto addressForUpdateDto)
    {
        if (addressId != addressForUpdateDto.Id) return BadRequest();

        var addressFromDatabase = Data.Instance.Customers.FirstOrDefault(customer => customer.Id == customerId)
            ?.Addresses.FirstOrDefault(address => address.Id == addressId);

        if (addressFromDatabase == null) return NotFound();

        addressFromDatabase.Street = addressForUpdateDto.Street;
        addressFromDatabase.Number = addressForUpdateDto.Number;
        addressFromDatabase.AdditionalInfo = addressForUpdateDto.AdditionalInfo;
        addressFromDatabase.Neighborhood = addressForUpdateDto.Neighborhood;
        addressFromDatabase.City = addressForUpdateDto.City;
        addressFromDatabase.Zip = addressForUpdateDto.Zip;

        return NoContent();
    }

    [HttpDelete("{addressId}")]
    public ActionResult DeleteAddress(int customerId, int addressId)
    {
        var customerForAddressDelete = Data.Instance.Customers.FirstOrDefault(customer => customer.Id == customerId);
        if (customerForAddressDelete == null) return NotFound();

        var addressFromDatabase = customerForAddressDelete.Addresses.FirstOrDefault(address => address.Id == addressId);
        if (addressFromDatabase == null) return NotFound();

        customerForAddressDelete.Addresses.Remove(addressFromDatabase);

        return NoContent();
    }
}