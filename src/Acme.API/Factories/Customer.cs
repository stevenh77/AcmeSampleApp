using System.Collections.Generic;

namespace Acme.API.Factories
{
    public class Customer
    {
        public static DTOs.Customer CreateFrom(
            Models.Customer customer,
            IEnumerable<Models.Category> categoryModels,
            IEnumerable<Models.Country> countryModels,
            IEnumerable<Models.Gender> genderModels)
        {
            return new DTOs.Customer()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Gender = Factories.Gender.CreateFrom(genderModels, customer.GenderId),
                    HouseNumber = customer.HouseNumber,
                    AddressLine1 = customer.AddressLine1,
                    State = customer.State,
                    Country = Factories.Country.CreateFrom(countryModels, customer.CountryId),
                    Category = Factories.Category.CreateFrom(categoryModels, customer.CategoryId),
                    DateOfBirth = customer.DateOfBirth
                };
        }

        public static Models.Customer CreateFrom(DTOs.Customer customer)
        {
            return new Models.Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
                GenderId = customer.Gender.Id,
                HouseNumber = customer.HouseNumber,
                AddressLine1 = customer.AddressLine1,
                State = customer.State,
                CountryId = customer.Country.Id,
                CategoryId = customer.Category.Id,
                DateOfBirth = customer.DateOfBirth,
                User = "APP_USER"
            };
        }
    }
}