using System;
using System.Linq;
using System.Web.Http;
using Acme.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.API.Controllers;

namespace Acme.API.Tests.Controllers
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void Given_Get_call_When_repos_and_data_are_valid_return_data()
        {
            // Arrange
            var mockCustomerRepo = Mocks.GetMockCustomerRepo().Object;
            var mockGenderRepo = Mocks.GetMockGenderRepo().Object;
            var mockCategoryRepo = Mocks.GetMockCategoryRepo().Object;
            var mockCountryRepo = Mocks.GetMockCountryRepo().Object;

            var controller = new CustomersController(
                mockCustomerRepo,
                mockGenderRepo,
                mockCategoryRepo,
                mockCountryRepo);

            var expectedCount = 3;

            // Act
            var result = controller.Get();

            // Assert
            Assert.AreEqual(expectedCount, result.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void Given_Get_call_When_repos_and_data_are_valid_except_for_empty_country_repo_then_expect_exception()
        {
            // Arrange
            var mockCustomerRepo = Mocks.GetMockCustomerRepo().Object;
            var mockGenderRepo = Mocks.GetMockGenderRepo().Object;
            var mockCategoryRepo = Mocks.GetMockCategoryRepo().Object;
            var mockEmptyCountryRepo = Mocks.GetMockEmptyCountryRepo().Object;

            var controller = new CustomersController(
                mockCustomerRepo,
                mockGenderRepo,
                mockCategoryRepo,
                mockEmptyCountryRepo);

            // Act
            controller.Get();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_new_controller_with_null_customersrepo_argumentnullexception_should_be_thrown()
        {
            new CustomersController(
                null, 
                new GenderRepository(), 
                new CategoryRepository(), 
                new CountryRepository());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_new_controller_with_null_genderrepo_argumentnullexception_should_be_thrown()
        {
            new CustomersController(
                new CustomerRepository(), 
                null, 
                new CategoryRepository(), 
                new CountryRepository());
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_new_controller_with_null_categoryrepo_argumentnullexception_should_be_thrown()
        {
            new CustomersController(
                new CustomerRepository(), 
                new GenderRepository(), 
                null, 
                new CountryRepository());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_new_controller_with_null_countryrepo_argumentnullexception_should_be_thrown()
        {
            new CustomersController(
                new CustomerRepository(), 
                new GenderRepository(), 
                new CategoryRepository(), 
                null);
        }
    }
}
