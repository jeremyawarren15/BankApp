using BankApp.Contracts.RepositoryContracts;
using BankApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _context;

        public AccountRepository(BankContext bankContext)
        {
            _context = bankContext;
        }

        public Account CreateAccount(Account account)
        {
            _context.Accounts.Add(account);

            _context.SaveChanges();

            return _context.Accounts.Find(account);
        }

        public bool DeleteAccount(Account account)
        {
            _context.Accounts.Remove(account);

            return _context.SaveChanges() == 1;
        }

        public IEnumerable<Account> GetAccountsByUser(User accountHolder)
        {
            return _context.Accounts
                .Where(x => x.AccountHolder == accountHolder)
                .ToList();
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }

        public Account UpdateAccount(Account updateAccount)
        {
            var account = _context.Accounts
                .Single(x => x.Id == updateAccount.Id);

            account.AccountHolder = updateAccount.AccountHolder;
            account.AccountType = updateAccount.AccountType;
            account.PIN = updateAccount.PIN;
            account.ModifiedDate = DateTimeOffset.UtcNow;

            _context.SaveChanges();

            return account;
        }
    }
}
