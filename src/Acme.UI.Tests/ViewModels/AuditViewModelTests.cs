using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.DTOs;
using Acme.UI.Services;
using Acme.UI.ViewModels;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Acme.UI.Tests.ViewModels
{
    [TestClass]
    public class AuditViewModelTests
    {
        [TestMethod]
        public void Given_new_viewmodel_CustomerAudits_should_not_be_null_and_IsLoading_should_be_false()
        {
            // arrange
            var mockServices = new Mock<IServiceProxy>();
            var mockLogger = new Mock<ILoggerFacade>();
            var mockEventAggregator = new Mock<IEventAggregator>();

            var fakeResult = Task.FromResult((IList<CustomerAudit>) new List<CustomerAudit>());
            mockServices.Setup(services => services.GetAllCustomerAudits()).Returns(fakeResult);
            
            // act
            var vm = new AuditViewModel(mockServices.Object, mockLogger.Object, mockEventAggregator.Object);
            
            // assert
            Assert.IsNotNull(vm.CustomerAudits);
            Assert.IsFalse(vm.IsLoading);
        }

        [TestMethod]
        public void Given_LoadAudits_is_called_IsLoading_should_go_through_two_state_changes_from_true_to_false()
        {
            // arrange
            var mockServices = new Mock<IServiceProxy>();
            var mockLogger = new Mock<ILoggerFacade>();
            var mockEventAggregator = new Mock<IEventAggregator>();

            var fakeResult = Task.FromResult((IList<CustomerAudit>)new List<CustomerAudit>());
            mockServices.Setup(services => services.GetAllCustomerAudits()).Returns(fakeResult);

            var isLoadingValues = new List<bool>();
            var vm = new AuditViewModel(mockServices.Object, mockLogger.Object, mockEventAggregator.Object);
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName != "IsLoading") return;
                isLoadingValues.Add(vm.IsLoading);
            };

            // act
            var task = vm.LoadAudits();    
            if(!task.IsCompleted) task.Wait();
            
            // assert
            Assert.AreEqual(isLoadingValues.Count, 2);
            Assert.IsTrue(isLoadingValues[0]);
            Assert.IsFalse(isLoadingValues[1]);
        }
    }
}
