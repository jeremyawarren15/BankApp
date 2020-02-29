using BankApp.Contracts;
using BankApp.Contracts.RepositoryContracts;
using BankApp.Data;
using BankApp.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account CreateAccount(User accountHolder, AccountTypes accountType, string PIN)
        {
            var account = new Account()
            {
                AccountHolder = accountHolder,
                AccountType = accountType,
                PIN = PIN
            };

            return _accountRepository.CreateAccount(account);
        }

        public bool DeleteAccount(Account account)
        {
            return _accountRepository.DeleteAccount(account);
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAll();
        }

        public IEnumerable<Account> GetAccounts(User accountHolder)
        {
            return _accountRepository.GetAccountsByUser(accountHolder);
        }

        public Account UpdateAccount(Account updatedAccount)
        {
            return _accountRepository.UpdateAccount(updatedAccount);
        }
    }
}
