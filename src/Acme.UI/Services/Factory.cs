using System;
using Acme.DTOs;
using Customer = Acme.UI.Models.Customer;

namespace Acme.UI.Services
{
    public class Factory
    {
        public static Customer Clone(Customer customer)
        {
            return new Customer()
            {
                AddressLine1 = customer.AddressLine1,
                Category = Clone(customer.Category),
                Country = Clone(customer.Country),
                DateOfBirth = customer.DateOfBirth,
                Gender = Clone(customer.Gender),
                HouseNumber = customer.HouseNumber,
                Id = customer.Id,
                Name = customer.Name,
                State = customer.State
            };
        }

        public static T Clone<T>(T data) where T : LookupData, new()
        {
            return new T()
            {
                Id = data.Id,
                Name = data.Name
            };
        }

        public static DTOs.Customer CreateFrom(Models.Customer customer)
        {
            if (!customer.DateOfBirth.HasValue) throw new Exception("Customer dateofbirth must be set");
            return new DTOs.Customer()
            {
                AddressLine1 = customer.AddressLine1,
                Category = customer.Category,
                Country = customer.Country,
                DateOfBirth = customer.DateOfBirth.Value,
                Gender = customer.Gender,
                HouseNumber = customer.HouseNumber,
                Id = customer.Id,
                Name = customer.Name,
                State = customer.State
            };
        }
    }
}
