using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.DTOs;
using Customer = Acme.UI.Models.Customer;

namespace Acme.UI.Services
{
    public class FakeServiceProxy : IServiceProxy
    {
        public async Task<IList<Customer>> SearchForCustomers(string searchString)
        {
            return await Task.FromResult(FakeData.GetCustomersForSearchResults());
        }

        public async Task<IList<Customer>> GetAllCustomers()
        {
            await Task.Delay(500);
            return await Task.FromResult(FakeData.GetCustomers());
        }

        public async Task<bool> Insert(Customer customer)
        {
            // return success
            await Task.Delay(500);
            return true;
        }

        public async Task<bool> Update(Customer customer)
        {
            // return success
            await Task.Delay(500);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            // return success
            await Task.Delay(500);
            return true;
        }

        public async Task<IList<CustomerAudit>> GetAllCustomerAudits()
        {
            await Task.Delay(500);
            return await Task.FromResult(FakeData.GetCustomerAudits());
        }

        public async Task<Tuple<IList<ChartData>, IList<ChartData>>> GetCustomersByCategoryAndLocation()
        {
            await Task.Delay(500);
            var categories = await Task.FromResult(FakeData.GetCategoryData());
            var locations = await Task.FromResult(FakeData.GetLocationData());
            var result = new Tuple<IList<ChartData>, IList<ChartData>>(categories.ToList(), locations.ToList());
            return await Task.FromResult(result);
        }

        public async Task<Tuple<IList<Category>, IList<Country>, IList<Gender>>> GetReferenceData()
        {
            var data = FakeData.GetReferenceData();
            return await Task.FromResult(data);
        }
    }
}
