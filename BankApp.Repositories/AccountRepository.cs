using BankApp.Contracts.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Account CreateAccount(Account account)
        {
            using (var ctx = new BankContext())
            {
                ctx.Accounts.Add(account);

                ctx.SaveChanges();

                return ctx.Accounts.Find(account);
            }
        }

        public bool DeleteAccount(Account account)
        {
            using (var ctx = new BankContext())
            {
                ctx.Accounts.Remove(account);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Account> GetAccountsByUser(User accountHolder)
        {
            using (var ctx = new BankContext())
            {
                return ctx.Accounts
                    .Where(x => x.AccountHolder == accountHolder)
                    .ToList();
            }
        }

        public IEnumerable<Account> GetAll()
        {
            using (var ctx = new BankContext())
            {
                return ctx.Accounts.ToList();
            }
        }

        public Account UpdateAccount(Account updateAccount)
        {
            using (var ctx = new BankContext())
            {
                var account = ctx.Accounts
                    .Single(x => x.Id == updateAccount.Id);

                account.AccountHolder = updateAccount.AccountHolder;
                account.AccountType = updateAccount.AccountType;
                account.PIN = updateAccount.PIN;
                account.ModifiedDate = DateTimeOffset.UtcNow;

                ctx.SaveChanges();

                return account;
            }
        }
    }
}
