// Written by Dr. Shane Wilson.
// The author licenses this file to you under the MIT license.
// See the LICENSE file in the solution root for more information.

using BankingTDD.Models;

namespace BankingTests
{
    public class BankAccountWithdrawlTests
    {
        [Fact]
        //<nameofmethod being tested>
        //The scenario being tested
        //The expected behaviour when the scenario is invoked
        public void MakeWithdrawl_ValidAmount_ChangesBalance()
        {
            //AAA Unit Testing
            //Arrange - the data we need for the test
            BankAccount testAccount = new BankAccount("14545", "Stephen Callaghan", 10.0m);
            decimal withdrawlAmount = -1.0m;
            decimal expectedResult = 9.0m;

            //Act - invoke the method being tested
            testAccount.MakeWithdrawal(withdrawlAmount, DateTime.Now, "Test Withdrawl");

            //Assert - expected result = actual result
            Assert.Equal(expectedResult, testAccount.Balance, 2);

        }
        [Fact]
        public void MakeWithdrawl_ValidAmount_BalanceUnchabnged()
        {
            //AAA Unit Testing
            //Arrange - the data we need for the test
            BankAccount testAccount = new BankAccount("14545", "Stephen Callaghan", 10.0m);
            decimal withdrawlAmount = -20.0m;
            //decimal expectedResult = 9.0m;

            //Act and assert
            Assert.Throws<ArgumentException>(() => testAccount.MakeWithdrawal(withdrawlAmount,
                DateTime.Now, "Test Withdrawl"));
            

            //Assert - expected result = actual result
            //Assert.Equal(expectedResult, testAccount.Balance, 2);

        }

        [Theory]
        [InlineData("14545", "Stephen Callaghan", 40.0, -20, 20)]
        public void MakeWithdrawls_ValidAmount_ChangesBalance(string accNumber, string owner,
            decimal startingBalance, decimal withdrawlAmount, decimal expectedBalance)
        {
            //AAA Unit Testing
            //Arrange - the data we need for the test
            BankAccount testAccount = new BankAccount(accNumber, owner, startingBalance);

            //Act - invoke the method being tested
            testAccount.MakeWithdrawal(withdrawlAmount, DateTime.Now, "Test Withdrawl");

            //Assert - expected result = actual result
            Assert.Equal(expectedBalance, testAccount.Balance, 2);

        }
    }
}
