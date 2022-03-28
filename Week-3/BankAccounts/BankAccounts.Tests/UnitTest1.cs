using Xunit;
using System;
using BankAccounts.App;

namespace BankAccounts.Test
{
    public class UnitTest1
    {
        // Unit tests are supposed to be laser focues on a particular behavior or function of a veru small unit of code!

        [Fact]
        public void Test1()
        {
            // ARRANGE - any set up that is required to perform the test.
            // ACT - where we invoke the behavior to test.
            // ASSERT - compare the result of the ACT to an expected value.

            Assert.Equal(true, true);
            // Assert.Equal((what we expect to get back, our control), (what we actually got back))    
        }

        // Typical naming convention
        // UnitOfTest_TestCondition_CorrectBehavior
        [Fact]
        public void SavingsAccount_CreateSavingsAccount_ValidSavingsAccoung()
        {
            // ARRANGE
            string expected = "testAccount";
            double savingsAcccountBalance = 1234.56;

            // ACT
            var account = new SavingsAccount(expected, savingsAcccountBalance);
            double actualAccountBalance = account.GetAccountBalance();
            // ASSERT
            Assert.Equal(account.accountName, expected);

        }

        [Fact]
        public void Transaction_CreateTransaction_ValidTransaction()
        {
            // ARRANGE
            DateTime time = DateTime.Now;

            // ACT
            Transaction tran = new Transaction(1500.50, time, "TestDeposit");

            // ASSERT
            Assert.Equal(tran.date, time);
        }

        [Fact]
        public void Account_GetInterestRate_ReturnInterestRate()
        {
            // ARRANGE
            SavingsAccount saving = new SavingsAccount("Test", 10000);
            double expectedInterestRate = 0.003;

            // ACT
            double actual = saving.GetInterestRate();

            // ASSERT
            Assert.Equal(expectedInterestRate, actual);
        }

        [Fact]
        public void Account_InvalidWithdrawal_allTransactionsLengthUnchanged()
        {
            // ARRANGE
            SavingsAccount savings = new SavingsAccount("testAccount", 1000);
            int expectedAllTransactionsCount = savings.GetTransactionsCount();

            // ACT
            savings.Withdrawal(1500);
            int actualAllTransactionsCount = savings.GetTransactionsCount();

            // ASSERT
            Assert.Equal(expectedAllTransactionsCount, actualAllTransactionsCount);

        }

        [Fact]
        public void DummyTest_CharNotInString()
        {
            // This test is to experiment with the Assert.DoesNotContain() method

            // ARRANGE
            var expected = "&";
            string actual = "this string does & contain an ampersand.";

            // ACT
            
            // ASSERT
            Assert.DoesNotContain(expected, actual);
        }
    }
}