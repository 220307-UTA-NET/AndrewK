namespace BankAccounts.App
{
    public class SavingsAccount : Account
    {
        // Fields

        // Constructors
        public SavingsAccount(string accountName, double accountBalance)
        //public SavingsAccount(string accountName, int accountNumber, double accountBalance)
        {
            this.accountName = accountName;
            //this.accountNumber = accountNumber;
            //this.accountBalance = accountBalance;
            this.Deposit(accountBalance, "First Deposit:");
            this.interestRate = 0.003;
        }

        // Methods
        // public override void Withdrawal(double amount)
        // {
        //     if(amount < 0)
        //     {
        //         Console.WriteLine("Withdrawals must be a positive value.");
        //         Console.WriteLine("Transaction canceled.");
        //         return;
        //     }
        //     else if((this.accountBalance - amount) < 0)
        //     {
        //         Console.WriteLine("Balance in account cannot go below 0.");
        //         Console.WriteLine("Transaction canceled.");
        //         return;
        //     }
        //     else
        //     {
        //         this.accountBalance -= amount;
        //         this.Record(-amount);
        //     }
        // }

        // public override void Deposit(double amount)
        // {
        //     if(amount < 0)
        //     {
        //         Console.WriteLine("Deposits must be a positive value.");
        //         Console.WriteLine("Transaction canceled.");
        //         return;
        //     }
        //     else
        //     {
        //         this.accountBalance += amount;
        //         this.Record(amount);
        //     }
        // }

        public void ApplyInterest()
        {
            //this.accountBalance += Math.Round((this.accountBalance * interestRate), 2);
            this.Deposit(Math.Round((this.accountBalance * interestRate), 2), "Interest payment.");
        }

    }
}