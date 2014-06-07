using System;

namespace Acme.DTOs
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string HouseNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string State { get; set; }
        public Country Country { get; set; }
        public Category Category { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
