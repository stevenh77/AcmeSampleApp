using System;

namespace Acme.API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenderId { get; set; }
        public string HouseNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string State { get; set; }
        public int CountryId { get; set; }
        public int CategoryId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string User { get; set; }
    }
}