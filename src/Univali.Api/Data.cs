using Univali.Api.Entities;

namespace Univali.Api
{
    public class Data
    {
        public List<Customer> Customers{get; set;}

        private Data()
        {
            Customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "John Doe",
                    Cpf = "12345678987",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Id = 1,
                            Street = "Main Street",
                            Number = 123,
                            Neighborhood = "Central",
                            City = "Winstonville",
                            Zip = "98765432"
                        },
                        new Address
                        {
                            Id = 2,
                            Street = "Sample Avenue",
                            Number = 1135,
                            Neighborhood = "Uptown",
                            City = "Winstonville",
                            Zip = "98765123"
                        }
                    }
                },
                new Customer
                {
                    Id = 2,
                    Name = "Jane Doe",
                    Cpf = "98765432123",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Id = 3,
                            Street = "Main Street",
                            Number = 456,
                            AdditionalInfo = "A",
                            Neighborhood = "Central",
                            City = "Winstonville",
                            Zip = "98765432"
                        }
                    }
                }
            };
        }

        private static Data? _instance;

        public static Data Instance
        {
            get
            {
                return _instance ??= new Data();
            }
        }
    }
}