using System.Xml.Serialization;

namespace BankAccounts
{
    class Account
    //abstract class Account
    // abstract class objects cannot be created.
    {
        // Fields
        private static int accountSeed = 111111;
        public string? accountName;
        protected int accountNumber;
        protected double accountBalance
        {
            get
            {
                double balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.amount;
                }
                return balance;
            }
        }
        protected double interestRate;

        // Create a List of Transaction object
        private List<Transaction> allTransactions = new List<Transaction>();
        // Construct an XmlSerializer that serializes a list of Transaction object
        public XmlSerializer Serializer {get;} = new(typeof(List<Transaction>));

        // Constructor
        // Once we declare the class as abstract, we cannot create the object anymore!
        public Account(){
            this.accountNumber = accountSeed;
            accountSeed++;
        }

        // Methods
        public int GetAccountNumber()
        {
            return this.accountNumber;
        }

        public double GetAccountBalance()
        {
            return this.accountBalance;
        }

        public double GetInterestRate()
        {
            return this.interestRate;
        }

        // abstract methods do not need a body because it will be overridden later on.
        //public abstract void Withdrawal(double withdrawal);
        public void Withdrawal(double amount, string note = "")
        {
            if(amount < 0)
            {
                Console.WriteLine("Withdrawals must be a positive value.");
                Console.WriteLine("Transaction canceled.");
                return;
            }
            else if((this.accountBalance - amount) < 0)
            {
                Console.WriteLine("Balance in account cannot go below 0.");
                Console.WriteLine("Transaction canceled.");
                return;
            }
            else
            {
                // this.accountBalance -= amount;
                // this.Record(-amount);

                var withdrawal = new Transaction(-amount, DateTime.Now, note);
                allTransactions.Add(withdrawal);
            }
        }

        //public abstract void Deposit(double amount);
        public void Deposit(double amount, string note = "")
        {
            if(amount < 0)
            {
                Console.WriteLine("Deposits must be a positive value.");
                Console.WriteLine("Transaction canceled.");
                return;
            }
            else
            {
                // this.accountBalance += amount;
                // this.Record(amount);

                var deposit = new Transaction(amount, DateTime.Now, note);
                allTransactions.Add(deposit);
            }
        }

        protected void Record(double transactionAmount)
        {
            DateTime current = DateTime.Now;
            string[] content = {(current.ToString("F")) + "\t" + this.accountNumber + "\t" + this.accountName + "\t" + transactionAmount + "\t" + this.accountBalance};

            string path = @".\TransactionRecords.txt";

            if(!File.Exists(path))
            {
                // Create and write to new file
                File.WriteAllLines(path, content);
            }
            else
            {
                // Append the existing file
                File.AppendAllLines(path, content);
            }
        }

        // Method to serialize List of Transaction object using a StringWriter
        public void SerializeAsXml()
        {
            var newStringWriter = new StringWriter();
            Serializer.Serialize(newStringWriter, allTransactions); // This is the conversion into Xml
            newStringWriter.Close();

            string path = $"./Transactions-{this.accountNumber}.xml";
            File.WriteAllText(path, newStringWriter.ToString());
        }

    }

}