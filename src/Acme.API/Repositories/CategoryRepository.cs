using System.Collections.Generic;
using System.Linq;
using Acme.API.Interfaces;
using Acme.API.Models;

namespace Acme.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetAll()
        {
            var categories = new[]
            {
                new Category() { Id = 1, Name = "Category A"},
                new Category() { Id = 2, Name = "Category B"},
                new Category() { Id = 3, Name = "Category C"},
            };
            return categories.AsQueryable();
        }
    }
}