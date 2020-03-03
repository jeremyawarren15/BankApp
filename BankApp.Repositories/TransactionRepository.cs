using BankApp.Contracts.RepositoryContracts;
using BankApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankContext _context;

        public TransactionRepository(BankContext context)
        {
            _context = context;
        }

        public Transaction CreateTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);

            _context.SaveChanges();

            return _context.Transactions.Find(transaction);
        }

        public bool DeleteTransaction(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);

            return _context.SaveChanges() == 1;
        }

        public IEnumerable<Transaction> GetTransactions(Account accounholder)
        {
            return _context.Transactions
                .Where(x => x.Account == accounholder)
                .ToList();
        }

        public Transaction UpdateTransaction(Transaction updatedAccount)
        {
            var oldTransaction = _context.Transactions.Single(x => x.Id == updatedAccount.Id);

            oldTransaction.Account = updatedAccount.Account;
            oldTransaction.CounterpartyAccount = updatedAccount.CounterpartyAccount;
            oldTransaction.Amount = updatedAccount.Amount;
            oldTransaction.TransactionType = updatedAccount.TransactionType;
            oldTransaction.ModifiedDate = DateTimeOffset.UtcNow;

            _context.SaveChanges();

            return _context.Transactions.Find(oldTransaction);
        }
    }
}
