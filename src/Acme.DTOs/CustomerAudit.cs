using System;

namespace Acme.DTOs
{
    public class CustomerAudit : Customer
    {
        public string CreateUser { get; set; }
        public DateTime CreateTimestamp { get; set; }
        public string EditUser { get; set; }
        public DateTime EditTimestamp { get; set; }
        public string Action { get; set; }
        public string ActionUser { get; set; }
        public DateTime ActionTimestamp { get; set; }
    }
}
