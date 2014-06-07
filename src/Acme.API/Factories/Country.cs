using System.Collections.Generic;
using System.Linq;

namespace Acme.API.Factories
{
    public class Country
    {
        public static DTOs.Country CreateFrom(IEnumerable<Models.Country> countries, int id)
        {
            var country = countries.First(x => x.Id == id);
            return new DTOs.Country() {Id = country.Id, Name = country.Name};
        }
    }
}