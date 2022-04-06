using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    class Customer
    {
        // Fields
        private int customerId;
        private int storeId;
        private string firstName;
        private string lastName;
        private string? address;
        private string? city;
        private string? state;
        private string? country;
        private string? zipCode;
        private string? phoneNumber;

        // Create a List of Order object for purchase/order history
        private List<Order> orderHistory = new List<Order>(); 

        // Constructors
        public Customer() { }

        public Customer(int customerId, string firstName, string lastName)
        {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Customer(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public Customer(string firstName, string lastName, string address, string city, string state, string country, string zipCode, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.country = country;
            this.zipCode = zipCode;
            this.phoneNumber = phoneNumber;
        }

        // Methods



        // Getters
        public int GetCustomerId()
        { return this.customerId; }

        public string GetFirstName()
        {
            return this.firstName;
        }

        public string GetLastName()
        {
            return this.lastName;
        }
        
        public string GetAddress()
        {
            return this.address;
        }

        public string GetCity()
        {
            return this.city;
        }

        public string GetCountry()
        { return this.country; }

        public string GetState()
        {
            return this.state;
        }

        public string GetZipCode()
        {
            return this.zipCode;
        }

        public string GetPhoneNumber()
        {
            return this.phoneNumber;
        }

        // Setters
        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public void SetCity(string city)
        {
            this.city = city;
        }

        public void SetState(string state)
        {
            this.state = state;
        }

        public void SetCountry(string country)
        {
            this.country = country;
        }

        public void SetZipCode(string zipCode)
        {
            this.zipCode = zipCode;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }



    }
}