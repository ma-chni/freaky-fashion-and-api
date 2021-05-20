using System;
using System.Collections.Generic;

namespace FreakyFashion.Entities
{
    public class Customer
    {
        public Customer(string firstName, string lastName, int phoneNumber, string socialSecurityNumber, string email, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            SocialSecurityNumber = socialSecurityNumber;
            Email = email;
            Address = address;
        }

        public Customer(int id, string firstName, string lastName, int phoneNumber, string socialSecurityNumber, string email, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            SocialSecurityNumber = socialSecurityNumber;
            Email = email;
            Address = address;
        }

        public Customer()
        {

        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public List<Order> Order { get; set; } = new List<Order>();
    }
}
