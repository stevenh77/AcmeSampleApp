using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.UI.Models;
using Acme.UI.Services;
using Acme.UI.ViewModels;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Acme.UI.Tests.ViewModels
{
    [TestClass]
    public class SearchViewModelTests
    {
        [TestMethod]
        public void Given_new_viewmodel_SearchResults_should_not_be_null_and_SearchString_should_be_empty_and_isLoading_is_false()
        {
            // arrange
            var mockServices = new Mock<IServiceProxy>();
            var mockLogger = new Mock<ILoggerFacade>();
            var mockEventAggregator = new Mock<IEventAggregator>();
            
            // act
            var vm = new SearchViewModel(mockServices.Object, mockLogger.Object, mockEventAggregator.Object);
            
            // assert
            Assert.IsNotNull(vm.SearchResults);
            Assert.AreEqual(vm.SearchString, string.Empty);
            Assert.IsFalse(vm.IsLoading);
            Assert.IsNotNull(vm.SearchCommand);
            Assert.IsFalse(vm.SearchCommand.CanExecute(null));
            Assert.AreEqual(string.Empty, vm.ErrorMessage);
        }

        [TestMethod]
        public void Given_a_search_string_greater_than_zero_SearchCommand_should_be_executable()
        {
            // arrange
            var mockServices = new Mock<IServiceProxy>();
            var mockLogger = new Mock<ILoggerFacade>();
            var mockEventAggregator = new Mock<IEventAggregator>();

            // act
            var vm = new SearchViewModel(mockServices.Object, mockLogger.Object, mockEventAggregator.Object);
            vm.SearchString = "test";

            // assert
            Assert.IsTrue(vm.SearchCommand.CanExecute(null));
            Assert.AreEqual(string.Empty, vm.ErrorMessage);
        }

        [TestMethod]
        public void Given_an_empty_search_string_SearchCommand_should_not_be_executable()
        {
            // arrange
            var mockServices = new Mock<IServiceProxy>();
            var mockLogger = new Mock<ILoggerFacade>();
            var mockEventAggregator = new Mock<IEventAggregator>();

            // act
            var vm = new SearchViewModel(mockServices.Object, mockLogger.Object, mockEventAggregator.Object);
            vm.SearchString = string.Empty;

            // assert
            Assert.IsFalse(vm.SearchCommand.CanExecute(null));
            Assert.AreEqual(string.Empty, vm.ErrorMessage);
        }

        [TestMethod]
        public void Given_a_search_string_greater_than_zero_which_is_then_set_to_empty_then_SearchCommand_should_not_be_executable()
        {
            // arrange
            var mockServices = new Mock<IServiceProxy>();
            var mockLogger = new Mock<ILoggerFacade>();
            var mockEventAggregator = new Mock<IEventAggregator>();

            // act
            var vm = new SearchViewModel(mockServices.Object, mockLogger.Object, mockEventAggregator.Object);
            vm.SearchString = "test";
            vm.SearchString = string.Empty;

            // assert
            Assert.IsFalse(vm.SearchCommand.CanExecute(null));
            Assert.AreEqual(string.Empty, vm.ErrorMessage);
        }

        [TestMethod]
        public void When_SearchForCustomers_is_called_IsLoading_should_go_through_two_state_changes_from_true_to_false()
        {
            // arrange
            var mockServices = new Mock<IServiceProxy>();
            var mockLogger = new Mock<ILoggerFacade>();
            var mockEventAggregator = new Mock<IEventAggregator>();

            var fakeResult = Task.FromResult((IList<Customer>)new List<Customer>());
            mockServices.Setup(services => services.SearchForCustomers("test")).Returns(fakeResult);
            
            var isLoadingValues = new List<bool>();
            var vm = new SearchViewModel(mockServices.Object, mockLogger.Object, mockEventAggregator.Object);
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName != "IsLoading") return;
                isLoadingValues.Add(vm.IsLoading);
            };

            // act
            vm.SearchString = "test";
            var task = vm.SearchForCustomers();
            if (!task.IsCompleted) task.Wait();

            // assert
            Assert.AreEqual(isLoadingValues.Count, 2);
            Assert.IsTrue(isLoadingValues[0]);
            Assert.IsFalse(isLoadingValues[1]);
            Assert.AreEqual(string.Empty, vm.ErrorMessage);
        }

        [TestMethod]
        public void When_SearchForCustomers_is_called_and_throws_an_exception_isloading_should_be_false()
        {
            // arrange
            var mockServices = new Mock<IServiceProxy>();
            var mockLogger = new Mock<ILoggerFacade>();
            var mockEventAggregator = new Mock<IEventAggregator>();

            var errorMessage = "Service broke!";
            mockServices.Setup(services => services.SearchForCustomers("exception")).Throws(new Exception(errorMessage));
            var vm = new SearchViewModel(mockServices.Object, mockLogger.Object, mockEventAggregator.Object);

            // act
            vm.SearchString = "exception";
            var task = vm.SearchForCustomers();
            if (!task.IsCompleted) task.Wait();

            // assert
            Assert.IsFalse(vm.IsLoading);
            Assert.AreEqual(vm.ErrorMessage, errorMessage);
        }
    }
}
