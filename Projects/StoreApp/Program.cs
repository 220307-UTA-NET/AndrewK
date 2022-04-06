using System;
using System.Collections.Generic;

namespace StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Store App starting");

            while (true)
            {
                Console.WriteLine("Choose option:");
                Console.WriteLine("[1] - Existing Customer");
                Console.WriteLine("[2] - New Customer");
                Console.WriteLine("[0] - Exit");

                int menu = int.Parse(Console.ReadLine());

                // Switch statements
                switch(menu)
                {
                    // Exit the App
                    case 0:
                        Console.WriteLine("Come again.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        return;
                    case 1:
                        //
                        Console.WriteLine("Enter first name:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter last name:");
                        string lastName = Console.ReadLine();

                        string conn9 = File.ReadAllText(@"/Revature/AndrewK/connectionString.txt");

                        IRepository repo9 = new SqlRepository(conn9);
                        Customer tempCustomer = repo9.GetCustomer(firstName, lastName);

                        if (tempCustomer.GetFirstName() == null && tempCustomer.GetLastName() == null)
                        {
                            Console.WriteLine("Customer does not exist.");
                            break;
                        }                        

                        Console.WriteLine("Hello " + tempCustomer.GetFirstName() + " " + tempCustomer.GetLastName());
                        Console.WriteLine("Customer Id: " + tempCustomer.GetCustomerId());
                        Console.WriteLine("Choose option");
                        Console.WriteLine("[1] - Place an Order");
                        Console.WriteLine("[2] - View Order History");
                        Console.WriteLine("[3] - View Store Inventory");
                        Console.WriteLine("[9] - Remove Account");
                        Console.WriteLine("[0] - Exit");

                        int option = int.Parse(Console.ReadLine());

                        switch(option)
                        {
                            // Exit the App
                            case 0:
                                Console.WriteLine("Goodbye.");
                                Console.WriteLine("Press Enter to continue.");
                                Console.ReadLine();
                                Console.Clear();
                                return;
                            case 1:
                                // Place an Order
                                Console.WriteLine("Select store id to order from:");
                                string conn3 = File.ReadAllText(@"/Revature/AndrewK/connectionString.txt");

                                IRepository repo3 = new SqlRepository(conn3);

                                IEnumerable<Location> tempLocation = repo3.GetStoreLocation();
                                foreach (Location location in tempLocation)
                                {
                                    Console.WriteLine(location.ViewLocation());
                                }

                                // WHILE LOOP TO ASK FOR MORE ORDER

                                int storeId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Select an item id to order:");

                                IEnumerable<Inventory> tempInventory1 = repo3.GetInventory();
                                foreach (Inventory item in tempInventory1)
                                {
                                    Console.WriteLine(item.ViewInventory());
                                }

                                int itemId = int.Parse(Console.ReadLine());

                                Inventory tempItem = new Inventory(itemId);

                                decimal total = 0.00M;

                                Console.WriteLine("Enter quantity:");
                                int itemQuantity = int.Parse(Console.ReadLine());

                                Inventory Item1 = repo3.GetItem(itemId);

                                if (Item1.GetItemQuantity() < itemQuantity)
                                {
                                    Console.WriteLine("We don't have that many item.");
                                    break;
                                }
                                else
                                {
                                    total = itemQuantity * Item1.GetItemPrice();

                                    Order order1 = repo3.CreateNewOrder(tempCustomer.GetCustomerId(), storeId, total);

                                    repo3.UpdateInventory(itemId, itemQuantity);

                                    Console.WriteLine("Order processed.");
                                    Console.WriteLine($"Item Ordered: {Item1.GetItemName()}\t Quantity: {itemQuantity}\t Total: {total}");
                                }
                                break;
                            case 2:
                                // View Order History
                                Console.WriteLine("Order History:");
                                IEnumerable<Order> tempHistory = repo9.GetOrderHistory(tempCustomer.GetCustomerId());
                                foreach (Order item in tempHistory)
                                {
                                    Console.WriteLine(item.ViewOrder());
                                }
                                break;
                            case 3:
                                // View Store Inventory
                                string conn1 = File.ReadAllText(@"/Revature/AndrewK/connectionString.txt");

                                IRepository repo1 = new SqlRepository(conn1);

                                IEnumerable<Inventory> tempInventory = repo1.GetInventory();
                                foreach(Inventory item in tempInventory)
                                {
                                    Console.WriteLine(item.ViewInventory());
                                }
                                break;
                            case 9:
                                //
                                Console.WriteLine("Enter first name:");
                                string removeFirst = Console.ReadLine();
                                Console.WriteLine("Enter last name:");
                                string removeLast = Console.ReadLine();

                                string conn0 = File.ReadAllText(@"/Revature/AndrewK/connectionString.txt");

                                IRepository repo0 = new SqlRepository(conn0);

                                repo0.DeleteCustomer(removeFirst, removeLast);

                                Console.WriteLine($"Customer {removeFirst} {removeLast} deleted.");
                                break;

                            default:
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("Press Enter to continue.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                        }
                        break;

                    case 2:
                        string connectionString = File.ReadAllText(@"/Revature/AndrewK/connectionString.txt");

                        IRepository repo = new SqlRepository(connectionString);

                        // Create a new customer
                        Console.WriteLine("Enter first name:");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter last name:");
                        lastName = Console.ReadLine();

                        if(firstName == null || lastName == null)
                        {
                            Console.WriteLine("Please enter a valid name.");
                            break;
                        }

                        Customer newCustomer = repo.CreateNewCustomer(firstName, lastName);

                        Console.WriteLine("Welcome " + newCustomer.GetFirstName() + " " + newCustomer.GetLastName());
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}