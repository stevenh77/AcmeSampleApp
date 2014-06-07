using System.Collections.Generic;
using Acme.API.Interfaces;
using Acme.API.Models;

namespace Acme.API.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public IEnumerable<Country> GetAll()
        {
            var countries = new[]
            {
                new Country() {Id = 1, Name = "United States"}
            };
            return countries;
        }
    }
}