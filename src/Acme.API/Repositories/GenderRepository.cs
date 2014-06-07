using System.Collections.Generic;
using Acme.API.Interfaces;
using Acme.API.Models;

namespace Acme.API.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        public IEnumerable<Gender> GetAll()
        {
            var genders = new[]
            {
                new Gender() { Id = 1, Name = "Female"},
                new Gender() { Id = 2, Name = "Male"},
                new Gender() { Id = 3, Name = "Unknown"},
            };
            return genders;
        }
    }
}