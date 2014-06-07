using System.Collections.Generic;
using System.Linq;

namespace Acme.API.Factories
{
    public class Gender
    {
        public static DTOs.Gender CreateFrom(IEnumerable<Models.Gender> genders, int id)
        {
            var gender = genders.First(x => x.Id == id);
            return new DTOs.Gender() { Id = gender.Id, Name = gender.Name };
        }
    }
}