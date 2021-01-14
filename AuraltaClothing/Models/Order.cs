using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Models
{
    public class Order
    {

        public int OrderId { get; set; }

        public int OrderNumber { get; set; }

        public string ClientId { get; set; }

        public ApplicationUser Client { get; set; }

        public DateTime Date { get; set; }

        // Client Info
        public string PayId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public string AddressOne { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        public string Currency { get; set; }

        public string Total { get; set; }

    }
}