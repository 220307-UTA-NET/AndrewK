using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    internal class Inventory
    {
        // Fields
        int itemId;
        string itemName;
        int itemQuantity;
        decimal itemPrice;

        // Constructors
        public Inventory() { }

        public Inventory(int itemId)
        {
            this.itemId = itemId;
        }

        public Inventory(int itemId, string itemName, int itemQuantity, decimal itemPrice)
        {
            this.itemId = itemId;
            this.itemName = itemName;
            this.itemQuantity = itemQuantity;
            this.itemPrice = itemPrice;
        }

        // Methods
        public string ViewInventory()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Id: {this.itemId}\t Name: {this.itemName}\t Quantity: {this.itemQuantity}\t Price: {this.itemPrice}");
            return sb.ToString();
        }

        public int GetItemId()
        { return this.itemId; }

        public string GetItemName()
        { return this.itemName; }

        public int GetItemQuantity()
        { return this.itemQuantity; }   

        public decimal GetItemPrice()
        { return this.itemPrice; }
    }
}
