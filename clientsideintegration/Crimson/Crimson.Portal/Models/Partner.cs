using System;

namespace Crimson.Portal.Models
{
    public class Partner
    {
        public Address Address { get; set; }
        public int Age { get; set; }
        public int ChildrenCount { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Firstname { get; set; }
        public string Honorific { get; set; }
        public string Job { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string PersonalStatus { get; set; }
        public Links Links { get; set; }
    }

    public class Links
    {
        public string Self { get; set; }
        public string Offers { get; set; }
        public string Proposals { get; set; }
        public string Contracts { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string District { get; set; }
    }

    public class SimplifiedPartner
    {
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Honorific { get; set; }
        public string Firstname { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
