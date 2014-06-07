using System;
using Acme.DTOs;

namespace Acme.UI.Models
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
        public DateTime? DateOfBirth { get; set; }

        public string ConcatenatedAddress
        {
            get { return string.Concat(HouseNumber, ", ", AddressLine1, ", ", State, ", ", Country.Name); }
        }

        public int Age
        {
            get
            {
                if (!DateOfBirth.HasValue) return -1;
                DateTime today = DateTime.Today;
                int age = today.Year - DateOfBirth.Value.Year;
                if (DateOfBirth > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}
