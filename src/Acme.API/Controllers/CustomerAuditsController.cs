using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Acme.API.Interfaces;
using Acme.DTOs;

namespace Acme.API.Controllers
{
    public class CustomerAuditsController : ApiController
    {
        private readonly ICustomerAuditRepository customerAuditRepository;
        private readonly IEnumerable<Models.Category> categoryModels;
        private readonly IEnumerable<Models.Country> countryModels;
        private readonly IEnumerable<Models.Gender> genderModels;

        public CustomerAuditsController(
            ICustomerAuditRepository customerAuditRepository,
            IGenderRepository genderRepository,
            ICategoryRepository categoryRepository,
            ICountryRepository countryRepository)
        {
            if (customerAuditRepository == null) throw new ArgumentNullException("customerAuditRepository");
            if (genderRepository == null) throw new ArgumentNullException("genderRepository");
            if (categoryRepository == null) throw new ArgumentNullException("categoryRepository");
            if (countryRepository == null) throw new ArgumentNullException("countryRepository");
            
            this.customerAuditRepository = customerAuditRepository;

            // static reference data, usually do this on start up and cache the data across the app
            genderModels = genderRepository.GetAll();
            categoryModels = categoryRepository.GetAll();
            countryModels = countryRepository.GetAll();
        }

        public IEnumerable<CustomerAudit> Get()
        {
            try
            {
                // read from database
                var models = customerAuditRepository.GetAll();

                // convert from db models to dtos
                var dtos = (from customerAudits in models
                           select Factories.CustomerAudit.CreateFrom(customerAudits, categoryModels, countryModels, genderModels))
                           .ToList();

                return dtos;
            }
            catch (Exception ex)
            {
                Debug.Write(string.Format("Exception: {0}", ex.Message)); // TODO:  Introduce logging service here

                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.ToString()),
                    ReasonPhrase = "Problem reading from database, possible causes are connectivity, permissions and reference data integrity.  See Content for full exception details."
                };
                throw new HttpResponseException(response);
            }
        }
    }
}
