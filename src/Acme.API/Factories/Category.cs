using System.Collections.Generic;
using System.Linq;

namespace Acme.API.Factories
{
    public class Category
    {
        public static DTOs.Category CreateFrom(IEnumerable<Models.Category> categories, int id)
        {
            var category = categories.First(x => x.Id == id);
            return new DTOs.Category() { Id = category.Id, Name = category.Name };
        }
    }
}