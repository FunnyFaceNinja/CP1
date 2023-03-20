using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingTDD.Models;

public class BankAccount
{
    // Private fields 
    private List<Transaction> _allTransactions = new List<Transaction>();
        

    // Properties
    public string AccountNumber { get; }
    public string Owner { get; set; }
        
    /// <summary>
    /// Gets the balance of the bank account.
    /// </summary>
    public decimal Balance
    {
        // TODO - implement the get. It should iterate through the all of the transactions 
        // and apply withdrawals or deposits to the account and return the balance
        get
        {
            decimal balance = 0;
            foreach(var transaction in _allTransactions)
            {
                balance += transaction.Amount;
            }
            return balance;
        }
        
    }


    // Constructor
    public BankAccount(string accountNumber, string owner, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        var initialDeposit = new Transaction(AccountNumber,
            initialBalance, DateTime.Now, TransactionType.Deposit,
            "Opening account balance");
        _allTransactions.Add(initialDeposit);
        // TODO - implement the constructor
        //throw new NotImplementedException();

    }

    /// <summary>
    /// The MakeDeposit adds a new Transaction to the account with the given amount and note
    /// </summary>
    /// <param name="amount"> A amount to add to the account</param>
    /// <param name="date">The date and time of the transaction</param>
    /// <param name="note">Any notes associated with the transaction</param>
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        // Todo - implement the MakeDeposit method
        throw new NotImplementedException();
    }

    /// <summary>
    /// The MakeWithdrawal adds a new Transaction to the account with the given amount and note. We 
    /// should check that the withdrawal amount does not exceed the account balance. If it does throw
    /// an argument exception. 
    /// </summary>
    /// <param name="amount">The amount to withdraw from the account</param>
    /// <param name="date"></param>
    /// <param name="note"></param>
    /// <exception cref="ArgumentException"></exception>
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        // TODO - implement the MakeWithdrawal method
        //throw new NotImplementedException();
        if(-amount > Balance)
        {
            throw new ArgumentException("You cannot withdraw more money than you have");
        }
        var withdrawl = new Transaction(AccountNumber,
            amount, DateTime.Now, TransactionType.Withdrawal,
            note);
        _allTransactions.Add(withdrawl);
    }
}

