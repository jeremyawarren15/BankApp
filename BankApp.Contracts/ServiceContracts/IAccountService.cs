using BankApp.Data.Models;
using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Contracts.ServiceContracts
{
    public interface IAccountService
    {
        Account CreateAccount(User accountHolder, AccountTypes accountType, string PIN);
        IEnumerable<Account> GetAccounts();
        IEnumerable<Account> GetAccounts(User accountHolder);
        Account UpdateAccount(Account account);
        bool DeleteAccount(Account account);
    }
}
