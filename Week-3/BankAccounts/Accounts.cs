namespace BankAccounts
{
    abstract class Account
    // abstract class objects cannot be created.
    {
        // Fields
        public string? accountName;
        protected int accountNumber;
        protected double accountBalance;
        protected double interestRate;

        // Constructor
        // Once we declare the class as abstract, we cannot create the object anymore!

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
        public abstract void Withdrawal(double withdrawal);

        public abstract void Deposit(double deposit);


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
    }

}