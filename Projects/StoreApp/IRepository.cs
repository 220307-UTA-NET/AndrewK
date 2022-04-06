using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    internal interface IRepository
    {
        Customer CreateNewCustomer(string firstName, string lastName);
        Customer GetCustomer(string FirstName, string LastName);
        IEnumerable<Inventory> GetInventory();
        IEnumerable<Order> GetOrderHistory(int customerId);
        IEnumerable<Location> GetStoreLocation();
        Order CreateNewOrder(int customerId, int storeId, decimal total);
        Inventory GetItem(int itemId);
        Order GetOrder(int orderId);
        void UpdateInventory(int itemId, int itemQuantity);

        void DeleteCustomer(string firstName, string lastName);

    }
}
