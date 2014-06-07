using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Acme.DTOs;
using Newtonsoft.Json;
using Customer = Acme.UI.Models.Customer;

namespace Acme.UI.Services
{
    public class ServiceProxy : IServiceProxy
    {
        private readonly string baseServiceUrl;

        public ServiceProxy()
        {
            baseServiceUrl = ConfigurationManager.AppSettings["baseServiceUrl"];
        }

        private async Task<T> Get<T>(string url) where T : new()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(new Uri(baseServiceUrl + url));
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        private async Task<bool> Post<T>(string url, T entity) where T : new()
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync(new Uri(baseServiceUrl + url), entity);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Delete failed, exception: " + response.Content);
                return true;
            }
        }

        private async Task<bool> Put<T>(string url, T entity) where T : new()
        {
            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync(new Uri(baseServiceUrl + url), entity);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Delete failed, exception: " + response.Content);
                return true;
            }
        }

        private async Task<bool> Delete(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(new Uri(baseServiceUrl + url));
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Delete failed, exception: " + response.Content);
                return true;
            }
        }

        public async Task<IList<Customer>> SearchForCustomers(string searchString)
        {
            return await this.Get<List<Customer>>("customers/search/" + searchString);
        }

        public async Task<IList<Customer>> GetAllCustomers()
        {
            return await this.Get<List<Customer>>("customers");
        }

        public async Task<bool> Insert(Customer model)
        {
            var dto = Factory.CreateFrom(model);
            return await this.Post("customers", dto);
        }

        public async Task<bool> Update(Customer model)
        {
            var dto = Factory.CreateFrom(model);
            return await this.Put(string.Format("customers/{0}", dto.Id), dto);
        }

        public async Task<bool> Delete(int id)
        {
            return await this.Delete(string.Format("customers/{0}", id));
        }

        public async Task<IList<CustomerAudit>> GetAllCustomerAudits()
        {
            return await this.Get<List<CustomerAudit>>("customeraudits");
        }

        public async Task<Tuple<IList<ChartData>, IList<ChartData>>> GetCustomersByCategoryAndLocation()
        {
            var stats = await this.Get<List<List<ChartData>>>("customers/bycategoryandlocation");
            var result = new Tuple<IList<ChartData>, IList<ChartData>>(stats[0], stats[1]);
            return result;
        }

        public async Task<Tuple<IList<Category>, IList<Country>, IList<Gender>>> GetReferenceData()
        {
            var data = FakeData.GetReferenceData();
            return await Task.FromResult(data);
        }
    }
}