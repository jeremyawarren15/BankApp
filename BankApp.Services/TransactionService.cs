using BankApp.Contracts.RepositoryContracts;
using BankApp.Contracts.ServiceContracts;
using BankApp.Data.Models;
using BankApp.Enums;
using System;
using System.Collections.Generic;
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
                Account = account,
                Amount = amount,
                TransactionType = TransactionTypes.Debit
            };

            return _transactionRepository.CreateTransaction(deposit);
        }

        public Transaction Transfer(Account account, Account conterpartyAccount, decimal amount)
        {
            var transfer = new Transaction()
            {
                Account = account,
                CounterpartyAccount = conterpartyAccount,
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

            var withdraw = new Transaction()
            {
                Account = account,
                Amount = amount,
                TransactionType = TransactionTypes.Credit
            };

            return _transactionRepository.CreateTransaction(withdraw);
        }
    }
}
