using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.DTOs;
using Customer = Acme.UI.Models.Customer;

namespace Acme.UI.Services
{
    public interface IServiceProxy
    {
        // maps to customer api controller
        Task<IList<Customer>> GetAllCustomers();
        Task<bool> Insert(Customer customer);
        Task<bool> Update(Customer customer);
        Task<bool> Delete(int id);
        Task<Tuple<IList<ChartData>, IList<ChartData>>> GetCustomersByCategoryAndLocation();
        Task<IList<Customer>> SearchForCustomers(string searchString);

        // maps to audit api controller
        Task<IList<CustomerAudit>> GetAllCustomerAudits();

        // maps to reference api controller (to be added, currently fake data being used)
        Task<Tuple<IList<Category>, IList<Country>, IList<Gender>>> GetReferenceData();
    }
}