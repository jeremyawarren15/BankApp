using BankApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Contracts.RepositoryContracts
{
    public interface IAccountRepository
    {
        Account CreateAccount(Account account);
        IEnumerable<Account> GetAll();
        IEnumerable<Account> GetAccountsByUser(User accountHolder);
        Account GetAccount(int accountId);
        Account UpdateAccount(Account updateAccount);
        bool DeleteAccount(Account account);
    }
}
