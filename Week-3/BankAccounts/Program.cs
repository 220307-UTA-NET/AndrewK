using System;

namespace BankAccounts
{
    class Program
    {
        static void Main()
        {
            SavingsAccount newSavingsAccount = new SavingsAccount("Personal Savings", 123456, 2500.75);
            
            Console.WriteLine("newSavingsAccount.accountName = " + newSavingsAccount.accountName);
            Console.WriteLine("Current account number: " + newSavingsAccount.GetAccountNumber());
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());
            Console.WriteLine("Current interest rate: " + newSavingsAccount.GetInterestRate());
        
            // Testing Withdrawal method
            newSavingsAccount.Withdrawal(1500);
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());
            newSavingsAccount.Withdrawal(1500);
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());
            newSavingsAccount.Withdrawal(-1000);
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());
        
            // Testing Deposit method
            newSavingsAccount.Deposit(-1000);
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());
            newSavingsAccount.Deposit(123);
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());
            
            // Testing ApplyInterest method
            newSavingsAccount.ApplyInterest();
            Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());
           
            CheckingAccount newCheckingAccount = new CheckingAccount("Personal Checking", 123457, 250);
            
            Console.WriteLine("newCheckingAccount.accountName = " + newCheckingAccount.accountName);
            Console.WriteLine("Current account number: " + newCheckingAccount.GetAccountNumber());
            Console.WriteLine("Current account balance: " + newCheckingAccount.GetAccountBalance());
            Console.WriteLine("Current interest rate: " + newCheckingAccount.GetInterestRate());
        
            // Testing Withdrawal method
            newCheckingAccount.Withdrawal(400);
            newCheckingAccount.Withdrawal(-100);
            newCheckingAccount.Withdrawal(200);
            Console.WriteLine("Current account balance: " + newCheckingAccount.GetAccountBalance());
        
            // Testing Deposit method
            newCheckingAccount.Deposit(-300);
            newCheckingAccount.Deposit(200);
            Console.WriteLine("Current account balance: " + newCheckingAccount.GetAccountBalance());
            
            // // Testing ApplyInterest method
            // newSavingsAccount.ApplyInterest();
            // Console.WriteLine("Current account balance: " + newSavingsAccount.GetAccountBalance());
           


            }
    }
}