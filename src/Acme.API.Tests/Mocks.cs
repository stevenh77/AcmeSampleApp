using System.Collections.Generic;
using Acme.API.Interfaces;
using Acme.API.Models;
using Moq;

namespace Acme.API.Tests
{
    public class Mocks
    {
        public static Mock<ICountryRepository> GetMockCountryRepo()
        {
            var mockCountryRepo = new Mock<ICountryRepository>();
            var fakeCountries = new List<Country>()
            {
                new Country() {Id = 1},
                new Country() {Id = 2}
            };
            mockCountryRepo.Setup(repo => repo.GetAll()).Returns(fakeCountries);
            return mockCountryRepo;
        }

        public static Mock<ICountryRepository> GetMockEmptyCountryRepo()
        {
            var mockCountryRepo = new Mock<ICountryRepository>();
            var fakeCountries = new List<Country>();
            mockCountryRepo.Setup(repo => repo.GetAll()).Returns(fakeCountries);
            return mockCountryRepo;
        }

        public static Mock<ICategoryRepository> GetMockCategoryRepo()
        {
            var mockCategoryRepo = new Mock<ICategoryRepository>();
            var fakeCategories = new List<Category>()
            {
                new Category() {Id = 1},
                new Category() {Id = 2}
            };
            mockCategoryRepo.Setup(repo => repo.GetAll()).Returns(fakeCategories);
            return mockCategoryRepo;
        }

        public static Mock<IGenderRepository> GetMockGenderRepo()
        {
            var mockGenderRepo = new Mock<IGenderRepository>();
            var fakeGenders = new List<Gender>()
            {
                new Gender() {Id = 1},
                new Gender() {Id = 2}
            };
            mockGenderRepo.Setup(repo => repo.GetAll()).Returns(fakeGenders);
            return mockGenderRepo;
        }

        public static Mock<ICustomerAuditRepository> GetMockCustomerAuditRepo()
        {
            var mockCustomerAuditRepo = new Mock<ICustomerAuditRepository>();
            var fakeCustomerAudits = new List<CustomerAudit>()
            {
                new CustomerAudit() {GenderId = 1, CountryId = 1, CategoryId = 1},
                new CustomerAudit() {GenderId = 2, CountryId = 2, CategoryId = 2},
                new CustomerAudit() {GenderId = 1, CountryId = 1, CategoryId = 2}
            };
            mockCustomerAuditRepo.Setup(repo => repo.GetAll()).Returns(fakeCustomerAudits);
            return mockCustomerAuditRepo;
        }

        public static Mock<ICustomerRepository> GetMockCustomerRepo()
        {
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            var fakeCustomers = new List<Customer>()
            {
                new Customer() {GenderId = 1, CountryId = 1, CategoryId = 1},
                new Customer() {GenderId = 2, CountryId = 2, CategoryId = 2},
                new Customer() {GenderId = 1, CountryId = 1, CategoryId = 2}
            };
            mockCustomerRepo.Setup(repo => repo.GetAll()).Returns(fakeCustomers);
            return mockCustomerRepo;
        }
    }
}
