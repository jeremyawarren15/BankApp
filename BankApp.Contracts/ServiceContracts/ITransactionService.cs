using BankApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Contracts.ServiceContracts
{
    public interface ITransactionService
    {
        Transaction Withdraw(Account account, decimal amount);
        Transaction Deposit(Account account, decimal amount);
        Transaction Transfer(Account account, Account conterpartyAccount, decimal amount);
        bool DeleteTransaction(Transaction transaction);
        decimal GetBalance(Account account);
    }
}
