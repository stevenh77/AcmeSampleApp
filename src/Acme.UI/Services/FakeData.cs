using System;
using System.Collections.Generic;
using System.Linq;
using Acme.DTOs;
using Acme.UI.Infrastructure;
using Acme.UI.Models;
using Customer = Acme.UI.Models.Customer;

namespace Acme.UI.Services
{
    public class FakeData
    {
        private readonly static IList<Customer> fakeCustomers = new List<Customer>(5)
        {
            new Customer()
            {
                AddressLine1 = "Under the bridge",
                Category = new Category() {Id = 1, Name = "Category A"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1977, 08, 18),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 1,
                Name = "Customer #1",
                HouseNumber = "1a",
                State = "Ohio"
            },
            new Customer()
            {
                AddressLine1 = "Around the corner",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1996, 12, 25),
                Gender = new Gender() {Id = 3, Name = "Unknown"},
                Id = 2,
                Name = "Customer #2",
                HouseNumber = "2b",
                State = "Washington"
            },
            new Customer()
            {
                AddressLine1 = "Beneath the steps",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 04, 22),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 3,
                Name = "Customer #3",
                HouseNumber = "3c",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Over the rainbow",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1970, 01, 30),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 4,
                Name = "Customer #4",
                HouseNumber = "4d",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Under the mountain",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 03, 11),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 5,
                Name = "Customer #5",
                HouseNumber = "5e",
                State = "New York"
            },
                        new Customer()
            {
                AddressLine1 = "Under the bridge",
                Category = new Category() {Id = 1, Name = "Category A"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1977, 08, 18),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 1,
                Name = "Customer #1",
                HouseNumber = "1a",
                State = "Ohio"
            },
            new Customer()
            {
                AddressLine1 = "Around the corner",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1996, 12, 25),
                Gender = new Gender() {Id = 3, Name = "Unknown"},
                Id = 2,
                Name = "Customer #2",
                HouseNumber = "2b",
                State = "Washington"
            },
            new Customer()
            {
                AddressLine1 = "Beneath the steps",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 04, 22),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 3,
                Name = "Customer #3",
                HouseNumber = "3c",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Over the rainbow",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1970, 01, 30),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 4,
                Name = "Customer #4",
                HouseNumber = "4d",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Under the mountain",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 03, 11),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 5,
                Name = "Customer #5",
                HouseNumber = "5e",
                State = "New York"
            },
                        new Customer()
            {
                AddressLine1 = "Under the bridge",
                Category = new Category() {Id = 1, Name = "Category A"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1977, 08, 18),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 1,
                Name = "Customer #1",
                HouseNumber = "1a",
                State = "Ohio"
            },
            new Customer()
            {
                AddressLine1 = "Around the corner",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1996, 12, 25),
                Gender = new Gender() {Id = 3, Name = "Unknown"},
                Id = 2,
                Name = "Customer #2",
                HouseNumber = "2b",
                State = "Washington"
            },
            new Customer()
            {
                AddressLine1 = "Beneath the steps",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 04, 22),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 3,
                Name = "Customer #3",
                HouseNumber = "3c",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Over the rainbow",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1970, 01, 30),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 4,
                Name = "Customer #4",
                HouseNumber = "4d",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Under the mountain",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 03, 11),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 5,
                Name = "Customer #5",
                HouseNumber = "5e",
                State = "New York"
            },
                        new Customer()
            {
                AddressLine1 = "Under the bridge",
                Category = new Category() {Id = 1, Name = "Category A"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1977, 08, 18),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 1,
                Name = "Customer #1",
                HouseNumber = "1a",
                State = "Ohio"
            },
            new Customer()
            {
                AddressLine1 = "Around the corner",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1996, 12, 25),
                Gender = new Gender() {Id = 3, Name = "Unknown"},
                Id = 2,
                Name = "Customer #2",
                HouseNumber = "2b",
                State = "Washington"
            },
            new Customer()
            {
                AddressLine1 = "Beneath the steps",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 04, 22),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 3,
                Name = "Customer #3",
                HouseNumber = "3c",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Over the rainbow",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1970, 01, 30),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 4,
                Name = "Customer #4",
                HouseNumber = "4d",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Under the mountain",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 03, 11),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 5,
                Name = "Customer #5",
                HouseNumber = "5e",
                State = "New York"
            },
                        new Customer()
            {
                AddressLine1 = "Under the bridge",
                Category = new Category() {Id = 1, Name = "Category A"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1977, 08, 18),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 1,
                Name = "Customer #1",
                HouseNumber = "1a",
                State = "Ohio"
            },
            new Customer()
            {
                AddressLine1 = "Around the corner",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1996, 12, 25),
                Gender = new Gender() {Id = 3, Name = "Unknown"},
                Id = 2,
                Name = "Customer #2",
                HouseNumber = "2b",
                State = "Washington"
            },
            new Customer()
            {
                AddressLine1 = "Beneath the steps",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 04, 22),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 3,
                Name = "Customer #3",
                HouseNumber = "3c",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Over the rainbow",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1970, 01, 30),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 4,
                Name = "Customer #4",
                HouseNumber = "4d",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Under the mountain",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 03, 11),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 5,
                Name = "Customer #5",
                HouseNumber = "5e",
                State = "New York"
            },
                        new Customer()
            {
                AddressLine1 = "Under the bridge",
                Category = new Category() {Id = 1, Name = "Category A"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1977, 08, 18),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 1,
                Name = "Customer #1",
                HouseNumber = "1a",
                State = "Ohio"
            },
            new Customer()
            {
                AddressLine1 = "Around the corner",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1996, 12, 25),
                Gender = new Gender() {Id = 3, Name = "Unknown"},
                Id = 2,
                Name = "Customer #2",
                HouseNumber = "2b",
                State = "Washington"
            },
            new Customer()
            {
                AddressLine1 = "Beneath the steps",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 04, 22),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 3,
                Name = "Customer #3",
                HouseNumber = "3c",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Over the rainbow",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1970, 01, 30),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 4,
                Name = "Customer #4",
                HouseNumber = "4d",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Under the mountain",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 03, 11),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 5,
                Name = "Customer #5",
                HouseNumber = "5e",
                State = "New York"
            },
                        new Customer()
            {
                AddressLine1 = "Under the bridge",
                Category = new Category() {Id = 1, Name = "Category A"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1977, 08, 18),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 1,
                Name = "Customer #1",
                HouseNumber = "1a",
                State = "Ohio"
            },
            new Customer()
            {
                AddressLine1 = "Around the corner",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1996, 12, 25),
                Gender = new Gender() {Id = 3, Name = "Unknown"},
                Id = 2,
                Name = "Customer #2",
                HouseNumber = "2b",
                State = "Washington"
            },
            new Customer()
            {
                AddressLine1 = "Beneath the steps",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 04, 22),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 3,
                Name = "Customer #3",
                HouseNumber = "3c",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Over the rainbow",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1970, 01, 30),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 4,
                Name = "Customer #4",
                HouseNumber = "4d",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Under the mountain",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 03, 11),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 5,
                Name = "Customer #5",
                HouseNumber = "5e",
                State = "New York"
            },
                        new Customer()
            {
                AddressLine1 = "Under the bridge",
                Category = new Category() {Id = 1, Name = "Category A"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1977, 08, 18),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 1,
                Name = "Customer #1",
                HouseNumber = "1a",
                State = "Ohio"
            },
            new Customer()
            {
                AddressLine1 = "Around the corner",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1996, 12, 25),
                Gender = new Gender() {Id = 3, Name = "Unknown"},
                Id = 2,
                Name = "Customer #2",
                HouseNumber = "2b",
                State = "Washington"
            },
            new Customer()
            {
                AddressLine1 = "Beneath the steps",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 04, 22),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 3,
                Name = "Customer #3",
                HouseNumber = "3c",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Over the rainbow",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1970, 01, 30),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 4,
                Name = "Customer #4",
                HouseNumber = "4d",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Under the mountain",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 03, 11),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 5,
                Name = "Customer #5",
                HouseNumber = "5e",
                State = "New York"
            },
                        new Customer()
            {
                AddressLine1 = "Under the bridge",
                Category = new Category() {Id = 1, Name = "Category A"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1977, 08, 18),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 1,
                Name = "Customer #1",
                HouseNumber = "1a",
                State = "Ohio"
            },
            new Customer()
            {
                AddressLine1 = "Around the corner",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1996, 12, 25),
                Gender = new Gender() {Id = 3, Name = "Unknown"},
                Id = 2,
                Name = "Customer #2",
                HouseNumber = "2b",
                State = "Washington"
            },
            new Customer()
            {
                AddressLine1 = "Beneath the steps",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 04, 22),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 3,
                Name = "Customer #3",
                HouseNumber = "3c",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Over the rainbow",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1970, 01, 30),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 4,
                Name = "Customer #4",
                HouseNumber = "4d",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Under the mountain",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 03, 11),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 5,
                Name = "Customer #5",
                HouseNumber = "5e",
                State = "New York"
            },
                        new Customer()
            {
                AddressLine1 = "Under the bridge",
                Category = new Category() {Id = 1, Name = "Category A"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1977, 08, 18),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 1,
                Name = "Customer #1",
                HouseNumber = "1a",
                State = "Ohio"
            },
            new Customer()
            {
                AddressLine1 = "Around the corner",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1996, 12, 25),
                Gender = new Gender() {Id = 3, Name = "Unknown"},
                Id = 2,
                Name = "Customer #2",
                HouseNumber = "2b",
                State = "Washington"
            },
            new Customer()
            {
                AddressLine1 = "Beneath the steps",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 04, 22),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 3,
                Name = "Customer #3",
                HouseNumber = "3c",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Over the rainbow",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1970, 01, 30),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 4,
                Name = "Customer #4",
                HouseNumber = "4d",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Under the mountain",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 03, 11),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 5,
                Name = "Customer #5",
                HouseNumber = "5e",
                State = "New York"
            },
                        new Customer()
            {
                AddressLine1 = "Under the bridge",
                Category = new Category() {Id = 1, Name = "Category A"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1977, 08, 18),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 1,
                Name = "Customer #1",
                HouseNumber = "1a",
                State = "Ohio"
            },
            new Customer()
            {
                AddressLine1 = "Around the corner",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1996, 12, 25),
                Gender = new Gender() {Id = 3, Name = "Unknown"},
                Id = 2,
                Name = "Customer #2",
                HouseNumber = "2b",
                State = "Washington"
            },
            new Customer()
            {
                AddressLine1 = "Beneath the steps",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 04, 22),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 3,
                Name = "Customer #3",
                HouseNumber = "3c",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Over the rainbow",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1970, 01, 30),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 4,
                Name = "Customer #4",
                HouseNumber = "4d",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Under the mountain",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 03, 11),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 5,
                Name = "Customer #5",
                HouseNumber = "5e",
                State = "New York"
            },
                        new Customer()
            {
                AddressLine1 = "Under the bridge",
                Category = new Category() {Id = 1, Name = "Category A"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1977, 08, 18),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 1,
                Name = "Customer #1",
                HouseNumber = "1a",
                State = "Ohio"
            },
            new Customer()
            {
                AddressLine1 = "Around the corner",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1996, 12, 25),
                Gender = new Gender() {Id = 3, Name = "Unknown"},
                Id = 2,
                Name = "Customer #2",
                HouseNumber = "2b",
                State = "Washington"
            },
            new Customer()
            {
                AddressLine1 = "Beneath the steps",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 04, 22),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 3,
                Name = "Customer #3",
                HouseNumber = "3c",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Over the rainbow",
                Category = new Category() {Id = 3, Name = "Category C"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1970, 01, 30),
                Gender = new Gender() {Id = 1, Name = "Female"},
                Id = 4,
                Name = "Customer #4",
                HouseNumber = "4d",
                State = "California"
            },
            new Customer()
            {
                AddressLine1 = "Under the mountain",
                Category = new Category() {Id = 2, Name = "Category B"},
                Country = new Country() {Id = 1, Name = "United States"},
                DateOfBirth = new DateTime(1982, 03, 11),
                Gender = new Gender() {Id = 2, Name = "Male"},
                Id = 5,
                Name = "Customer #5",
                HouseNumber = "5e",
                State = "New York"
            },
        };

        public static IList<Customer> GetCustomersForSearchResults()
        {
            return fakeCustomers.Take(5).ToList();
        }

        public static IList<CustomerAudit> GetCustomerAudits()
        {
            var audits = fakeCustomers.Take(5).AsQueryable().Project().To<CustomerAudit>().ToList();

            var user = "YOU";
            var now = DateTime.Now;

            foreach (var audit in audits)
            {
                audit.Action = "T";
                audit.ActionUser = user;
                audit.CreateUser = user;
                audit.EditUser = user;
                audit.ActionTimestamp = now;
                audit.CreateTimestamp = now;
                audit.EditTimestamp = now;
            }

            return audits;
        }

        public static IList<ChartData> GetCategoryData()
        {
            return new List<ChartData>()
            {
                new ChartData() {Title = "Category A: 1 customer", Count = 1 },
                new ChartData() {Title = "Category B: 2 customers", Count = 2 },
                new ChartData() {Title = "Category C: 2 customers", Count = 2 },
            };
        }

        public static IList<ChartData> GetLocationData()
        {
            return new List<ChartData>()
            {
                new ChartData() {Title = "California, United States: 2 customers", Count = 2 },
                new ChartData() {Title = "New York, United States: 1 customer", Count = 1 },
                new ChartData() {Title = "Ohio, United States: 1 customer", Count = 1 },
                new ChartData() {Title = "Washington, United States: 1 customer", Count = 1 },
            };
        }

        public static IList<Customer> GetCustomers()
        {
            return fakeCustomers;
        }

        public static Tuple<IList<Category>, IList<Country>, IList<Gender>> GetReferenceData()
        {
            var fakeCategories = new List<Category>()
            {
                new Category() {Id = 1, Name = "Category A"},
                new Category() {Id = 2, Name = "Category B"},
                new Category() {Id = 3, Name = "Category C"}
            };
            var fakeCountries = new List<Country>()
            {
                new Country() {Id = 1, Name = "United States"}
            };
            var fakeGenders = new List<Gender>()
            {
                new Gender() {Id = 1, Name = "Female"},
                new Gender() {Id = 2, Name = "Male"},
                new Gender() {Id = 3, Name = "Unknown"}
            };
            return new Tuple<IList<Category>, IList<Country>, IList<Gender>>(fakeCategories, fakeCountries, fakeGenders);
        } 
    }
}