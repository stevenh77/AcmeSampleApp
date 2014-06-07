using Acme.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.UI.Tests.ViewModels
{
    [TestClass]
    public class ServicesViewModelTests
    {
        [TestMethod]
        public void Given_new_viewmodel_Message_should_not_be_null_or_empty()
        {
            // arrange and act
            var vm = new ServicesViewModel();
            
            // assert
            Assert.IsFalse(string.IsNullOrEmpty(vm.Message));
        }
    }
}
