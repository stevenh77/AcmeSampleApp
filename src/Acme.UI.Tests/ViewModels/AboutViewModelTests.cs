using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.DTOs;
using Acme.UI.Services;
using Acme.UI.ViewModels;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.UI.Tests.ViewModels
{
    [TestClass]
    public class AboutViewModelTests
    {
        [TestMethod]
        public void Given_new_viewmodel_TechnologySkills_should_not_be_null_and_should_count_some_items()
        {
            // arrange and act
            var vm = new AboutViewModel();

            // assert
            Assert.IsNotNull(vm.TechnologyList);
            Assert.IsTrue(vm.TechnologyList.Length > 0);
        }
    }
}
