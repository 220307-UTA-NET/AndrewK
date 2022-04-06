using System.Data.SqlClient;

namespace StoreApp
{
    internal class SqlRepository : IRepository
    {
        // Fields
        private readonly string _connectionString;

        // Constructors
        public SqlRepository(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        // Methods
        public Customer CreateNewCustomer(string FirstName, string LastName)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText =
                @"INSERT INTO Store.Customer (FirstName, LastName)
                VALUES
                    (@first, @last);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@first", FirstName);
            cmd.Parameters.AddWithValue("@last", LastName);

            cmd.ExecuteNonQuery();

            cmdText =
                @"SELECT FirstName, LastName
                FROM Store.Customer
                WHERE FirstName = @first AND LastName = @last;";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            cmd2.Parameters.AddWithValue("@first", FirstName);
            cmd2.Parameters.AddWithValue("@last", LastName);

            using SqlDataReader reader = cmd2.ExecuteReader();

            Customer tempCustomer;
            while (reader.Read())
            {
                return tempCustomer = new Customer(reader.GetString(0), reader.GetString(1));
            }
            connection.Close();
            Customer noCustomer = new();
            return noCustomer;
        }

        public IEnumerable<Inventory> GetInventory()
        {
            List<Inventory> inventory = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "SELECT ItemId, Name, Quantity, Price " +
                "FROM Store.Inventory;", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int quantity = reader.GetInt32(2);
                decimal price = reader.GetDecimal(3);
                inventory.Add(new(id, name, quantity, price));
            }
            connection.Close();
            return inventory;
        }

        public IEnumerable<Order> GetOrderHistory(int customerId)
        {
            List<Order> history = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                @"SELECT * " +
                "FROM Store.Invoice " +
                "WHERE CustomerId = @customerId;", connection);

            cmd.Parameters.AddWithValue("@customerId", customerId);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int orderId = reader.GetInt32(0);
                int customerId1 = reader.GetInt32(1);
                int storeId = reader.GetInt32(2);
                DateTime date = reader.GetDateTime(3);
                decimal total = reader.GetDecimal(4);
                history.Add(new(orderId, customerId1, storeId, date, total));
            }
            connection.Close();
            return history;
        }

        public IEnumerable<Location> GetStoreLocation()
        {
            List<Location> location = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "Select *" +
                "FROM Store.Location", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string address = reader.GetString(1);
                string city = reader.GetString(2);
                string state = reader.GetString(3);
                string country = reader.GetString(4);
                string zip = reader.GetString(5);
                string phone = reader.GetString(6);
                location.Add(new(id, address, city, state, country, zip, phone));
            }
            connection.Close();
            return location;
        }

        public Customer GetCustomer(string FirstName, string LastName)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText =
                @"SELECT * 
                FROM Store.Customer 
                WHERE FirstName = @first AND LastName = @last;";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            cmd2.Parameters.AddWithValue("@first", FirstName);
            cmd2.Parameters.AddWithValue("@last", LastName);

            using SqlDataReader reader = cmd2.ExecuteReader();

            Customer tempCustomer;
            while (reader.Read())
            {
                return tempCustomer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
            connection.Close();
            Customer noCustomer = new();
            return noCustomer;
        }

        public Inventory GetItem(int itemId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText =
                @"SELECT *
                FROM Store.Inventory
                WHERE ItemId = @itemId ;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@itemId", itemId);

            using SqlDataReader reader = cmd.ExecuteReader();

            Inventory tempItem;
            while (reader.Read())
            {
                return tempItem = new Inventory(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDecimal(3));
            }
            connection.Close();
            Inventory noItem = new();
            return noItem;
        }

        public Order CreateNewOrder(int customerId, int storeId, decimal total)
        {
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            DateTime tempDate = DateTime.Now;

            using SqlCommand cmd = new(
                @"INSERT INTO Store.Invoice (CustomerId, StoreId, InvoiceDate, Total) " +
                "VALUES " +
                "(@customerId, @storeId, @tempDate, @total);"
                , connection);

            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@storeId", storeId);
            cmd.Parameters.AddWithValue("@tempDate", tempDate);
            cmd.Parameters.AddWithValue("@total", total);

            cmd.ExecuteNonQuery();

            string cmdText =
                @"SELECT TOP 1 *
                FROM Store.Invoice 
                ORDER BY InvoiceId DESC;";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            using SqlDataReader reader = cmd2.ExecuteReader();

            Order tempOrder;
            while (reader.Read())
            {
                return tempOrder = new Order(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetDecimal(4));
            }
            connection.Close();
            Order noOrder = new();
            return noOrder;
        }

        public Order GetOrder(int orderId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText =
                @"SELECT *
                FROM Store.Invoice
                WHERE invoiceId = @orderId ;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@orderId", orderId);

            using SqlDataReader reader = cmd.ExecuteReader();

            Order tempOrder;
            while (reader.Read())
            {
                return tempOrder = new Order(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),reader.GetDateTime(3), reader.GetDecimal(4));
            }
            connection.Close();
            Order noOrder = new();
            return noOrder;

        }

        public void UpdateInventory(int itemId, int itemQuantity)
        {
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                @"UPDATE Store.Inventory " +
                "SET Quantity = Quantity - @itemQuantity " +
                "WHERE ItemId = @itemId;"
                , connection);

            cmd.Parameters.AddWithValue("@itemId", itemId);
            cmd.Parameters.AddWithValue("@itemQuantity", itemQuantity);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteCustomer(string firstName, string lastName)
        {
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                @"DELETE FROM Store.Customer " +
                "WHERE FirstName = @firstName AND LastName = @lastName;"
                , connection);

            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}
