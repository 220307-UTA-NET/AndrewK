using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    class Location
    {
        // Fields
        private int storeId;
        private string address;
        private string city;
        private string state;
        private string country;
        private string zipCode;
        private string phoneNumber;

        // List<Inventory> = new List<Inventory>();

        // Constructor
        public Location(int storeId, string address, string city, string state, string country, string zipCode, string phoneNumber)
        {
            this.storeId = storeId;
            this.address = address;
            this.city = city;
            this.state = state;
            this.country = country;
            this.zipCode = zipCode;
            this.phoneNumber = phoneNumber;
        }

        // Methods
        public string ViewLocation()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Id: {this.storeId}\t Address: {this.address}, {this.city}, {this.state}, {this.country}, {this.zipCode}\t Phone Number: {this.phoneNumber}");
            return sb.ToString();
        }

        public string GetAddress()
        { return this.address; }

        public string GetCity()
        { return this.city; }

        public string GetState()
        { return this.state; }

        public string GetCountry()
        { return this.country; }


    }
}