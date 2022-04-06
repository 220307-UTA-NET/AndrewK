using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    class Order
    {
        // Fields
        private int orderId;
        private int customerId;
        private int storeId;
        private DateTime date;
        private decimal total;
        //private List<string> itemList = new List<string>();

        // Constructors
        public Order() { }

        public Order(int orderId)
        {
            this.orderId = orderId;
        }

        public Order(int orderId, int customerId, int storeId, DateTime date, decimal total)
        {
            this.orderId = orderId;
            this.customerId = customerId;
            this.storeId = storeId;
            this.date = date;
            this.total = total;
        }


        // Methods
        public string ViewOrder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Date: {this.date}\t Customer Id: {this.customerId}\t Order Number: {this.orderId}\t Store Number: {this.storeId}\t Total: {this.total}");
            return sb.ToString();
        }


        public DateTime GetDate()
        { return this.date; }

        public int GetOrderId()
        { return this.orderId; }
    }
}