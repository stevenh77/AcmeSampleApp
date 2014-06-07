using System.Collections.Generic;

namespace Acme.API.Factories
{
    public class CustomerAudit
    {
        public static DTOs.CustomerAudit CreateFrom(
            Models.CustomerAudit audit,
            IEnumerable<Models.Category> categoryModels,
            IEnumerable<Models.Country> countryModels,
            IEnumerable<Models.Gender> genderModels)
        {
            return new DTOs.CustomerAudit()
            {
                Id = audit.Id,
                Name = audit.Name,
                Gender = Factories.Gender.CreateFrom(genderModels, audit.GenderId),
                HouseNumber = audit.HouseNumber,
                AddressLine1 = audit.AddressLine1,
                State = audit.State,
                Country = Factories.Country.CreateFrom(countryModels, audit.CountryId),
                Category = Factories.Category.CreateFrom(categoryModels, audit.CategoryId),
                DateOfBirth = audit.DateOfBirth,
                CreateUser = audit.CreateUser,
                CreateTimestamp = audit.CreateTimestamp,
                EditUser = audit.EditUser,
                EditTimestamp = audit.ActionTimestamp,
                Action = audit.Action,
                ActionUser = audit.ActionUser, 
                ActionTimestamp = audit.ActionTimestamp
            };
        }
    }
}