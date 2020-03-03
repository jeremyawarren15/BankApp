using BankApp.Data.Models;
using System.Collections.Generic;

namespace BankApp.Contracts.RepositoryContracts
{
    public interface ITransactionRepository
    {
        Transaction CreateTransaction(Transaction transaction);
        IEnumerable<Transaction> GetTransactions(Account accounholder);
        Transaction UpdateTransaction(Transaction updatedAccount);
        bool DeleteTransaction(Transaction transaction);
    }
}
