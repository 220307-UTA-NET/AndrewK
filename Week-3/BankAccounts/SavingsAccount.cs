namespace BankAccounts
{
    class SavingsAccount : Account
    {
        // Fields
        double interestRate = 0.003;

        // Constructors
        public SavingsAccount(string accountName, int accountNumber, double accountBalance)
        {
            this.accountName = accountName;
            this.accountNumber = accountNumber;
            this.accountBalance = accountBalance;
        }

        // Methods
        public override void Withdrawal(double withdrawal)
        {
            if(withdrawal < 0)
            {
                Console.WriteLine("Withdrawals must be a positive value.");
                Console.WriteLine("Transaction canceled.");
                return;
            }
            else if((this.accountBalance - withdrawal) < 0)
            {
                Console.WriteLine("Balance in account cannot go below 0.");
                Console.WriteLine("Transaction canceled.");
                return;
            }
            else
            {
                this.accountBalance -= withdrawal;
                this.Record(-withdrawal);
            }
        }

        public override void Deposit(double deposit)
        {
            if(deposit < 0)
            {
                Console.WriteLine("Deposits must be a positive value.");
                Console.WriteLine("Transaction canceled.");
                return;
            }
            else
            {
                this.accountBalance += deposit;
                this.Record(deposit);
            }
        }

        public void ApplyInterest()
        {
            this.accountBalance += Math.Round((this.accountBalance * interestRate), 2);
        }

    }
}