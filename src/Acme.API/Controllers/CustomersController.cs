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
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IEnumerable<Models.Category> categoryModels;
        private readonly IEnumerable<Models.Country> countryModels;
        private readonly IEnumerable<Models.Gender> genderModels;

        public CustomersController(
            ICustomerRepository customerRepository,
            IGenderRepository genderRepository,
            ICategoryRepository categoryRepository,
            ICountryRepository countryRepository)
        {
            if (customerRepository == null) throw new ArgumentNullException("customerRepository");
            if (genderRepository == null) throw new ArgumentNullException("genderRepository");
            if (categoryRepository == null) throw new ArgumentNullException("categoryRepository");
            if (countryRepository == null) throw new ArgumentNullException("countryRepository");

            this.customerRepository = customerRepository;

            // static reference data, usually do this on start up and cache the data across the app
            genderModels = genderRepository.GetAll();
            categoryModels = categoryRepository.GetAll();
            countryModels = countryRepository.GetAll();
        }

        public IEnumerable<Customer> Get()
        {
            try
            {
                // read from database
                var models = customerRepository.GetAll();

                // convert from db models to dtos
                var dtos = (from customers in models
                            select Factories.Customer.CreateFrom(customers, categoryModels, countryModels, genderModels))
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

        public Customer Get(int id)
        {
            try
            {
                // read from database
                var model = customerRepository.Get(id);
                if (model == null) throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

                // convert from db model to dto
                var dto = Factories.Customer.CreateFrom(model, categoryModels, countryModels, genderModels);

                return dto;
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

        [HttpGet]
        [Route("~/api/customers/bycategoryandlocation")]
        public IEnumerable<IEnumerable<ChartData>> ByCategoryAndLocation()
        {
            try
            {
                // read from database
                var dtos = customerRepository.GetCustomersByCategoryAndLocation();
                if (dtos == null) throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
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

        [HttpGet]
        [Route("~/api/customers/search/{searchString}")]
        public IEnumerable<Customer> Search(string searchString)
        {
            try
            {
                // read from database
                var models = customerRepository.Search(searchString);

                // convert from db models to dtos
                var dtos = (from customers in models
                            select Factories.Customer.CreateFrom(customers, categoryModels, countryModels, genderModels))
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

        [HttpPost]
        public void Post([FromBody]Customer dto)
        {
            try
            {
                var model = Factories.Customer.CreateFrom(dto);
                customerRepository.Insert(model);
            }
            catch (Exception ex)
            {
                Debug.Write(string.Format("Exception: {0}", ex.Message)); // TODO:  Introduce logging service here

                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.ToString()),
                    ReasonPhrase = "Error"
                };
                throw new HttpResponseException(response);
            }
        }
        
        [HttpPut]
        public void Put(int id, [FromBody]Customer dto)
        {
            try
            {
                if (id!=dto.Id) throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
                var model = Factories.Customer.CreateFrom(dto);
                customerRepository.Update(model);
            }
            catch (Exception ex)
            {
                Debug.Write(string.Format("Exception: {0}", ex.Message)); // TODO:  Introduce logging service here

                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.ToString()),
                    ReasonPhrase = "Error"
                };
                throw new HttpResponseException(response);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                customerRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Debug.Write(string.Format("Exception: {0}", ex.Message)); // TODO:  Introduce logging service here

                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.ToString()),
                    ReasonPhrase = "Error"
                };
                throw new HttpResponseException(response);
            }
        }
    }
}