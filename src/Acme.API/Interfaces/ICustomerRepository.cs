using System.Collections.Generic;
using Acme.DTOs;
using Customer = Acme.API.Models.Customer;

namespace Acme.API.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> Search(string searchString);
        IEnumerable<IEnumerable<ChartData>> GetCustomersByCategoryAndLocation();
    }
}