using BankApp.Contracts.RepositoryContracts;
using BankApp.Contracts.ServiceContracts;
using BankApp.Data.Models;
using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public bool DeleteTransaction(Transaction transaction)
        {
            return _transactionRepository.DeleteTransaction(transaction);
        }

        public Transaction Deposit(Account account, decimal amount)
        {
            var deposit = new Transaction()
            {
                AccountId = account.Id,
                Amount = amount,
                TransactionType = TransactionTypes.Debit
            };

            return _transactionRepository.CreateTransaction(deposit);
        }

        public decimal GetBalance(Account account)
        {
            var transactions = _transactionRepository.GetTransactions(account)
                .OrderBy(x => x.CreatedDate);

            decimal sum = 0;

            foreach (var transaction in transactions)
            {
                switch (transaction.TransactionType)
                {
                    case TransactionTypes.Debit:
                        sum += transaction.Amount;
                        break;
                    case TransactionTypes.Credit:
                        sum -= transaction.Amount;
                        break;
                    case TransactionTypes.Transfer:
                        if (transaction.Account == account)
                        {
                            sum -= transaction.Amount;
                        }
                        else if (transaction.CounterpartyAccount == account)
                        {
                            sum += transaction.Amount;
                        }
                        break;
                }
            }

            return sum;
        }

        public Transaction Transfer(Account account, Account conterpartyAccount, decimal amount)
        {
            if (GetBalance(account) - amount < 0)
            {
                return null;
            }

            var transfer = new Transaction()
            {
                AccountId = account.Id,
                CounterpartyAccountId = conterpartyAccount.Id,
                TransactionType = TransactionTypes.Transfer,
                Amount = amount
            };

            return _transactionRepository.CreateTransaction(transfer);
        }

        public Transaction Withdraw(Account account, decimal amount)
        {
            if (account.AccountType == AccountTypes.IndividualInvestment && amount > 1000)
            {
                return null;
            }

            if (GetBalance(account) - amount < 0)
            {
                return null;
            }

            var withdraw = new Transaction()
            {
                AccountId = account.Id,
                Amount = amount,
                TransactionType = TransactionTypes.Credit
            };

            return _transactionRepository.CreateTransaction(withdraw);
        }
    }
}
