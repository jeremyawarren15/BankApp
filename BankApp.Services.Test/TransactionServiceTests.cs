using BankApp.Contracts.RepositoryContracts;
using BankApp.Data.Models;
using BankApp.Enums;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Services.Test
{
    [TestFixture]
    public class TransactionServiceTests
    {
        [Test]
        public void IndividualAccountsCannotWithdrawMoreThan1000()
        {
            var account = new Account()
            {
                AccountType = AccountTypes.IndividualInvestment
            };

            var transaction = new Transaction()
            {
                Account = account,
                Amount = 1001
            };

            var repository = new Mock<ITransactionRepository>();
            repository.Setup(x => x.CreateTransaction(It.IsAny<Transaction>())).Returns(transaction);
            var service = new TransactionService(repository.Object);

            var result = service.Withdraw(account, transaction.Amount);

            Assert.Null(result);
        }

        [Test]
        public void CannotOverdrawAccountOnWithdraw()
        {
            var account = new Account()
            {
                Id = 1
            };

            var transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    AccountId = account.Id,
                    Amount = 1000,
                    TransactionType = TransactionTypes.Debit,
                    CreatedDate = DateTimeOffset.Parse("1/1/2020")
                }
            };

            var repository = new Mock<ITransactionRepository>(MockBehavior.Strict);
            repository.Setup(x => x.GetTransactions(It.IsAny<Account>())).Returns(transactions);
            var service = new TransactionService(repository.Object);

            var result = service.Withdraw(account, 2000);
            // Test passes if repository.CreateTransaction is not called
        }

        [Test]
        public void CannotOverdrawAccountOnTransfer()
        {
            var account = new Account()
            {
                Id = 1
            };
            var counterAccount = new Account()
            {
                Id = 2
            };

            var transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    AccountId = account.Id,
                    Amount = 1000,
                    TransactionType = TransactionTypes.Debit,
                    CreatedDate = DateTimeOffset.Parse("1/1/2020")
                }
            };

            var repository = new Mock<ITransactionRepository>(MockBehavior.Strict);
            repository.Setup(x => x.GetTransactions(It.IsAny<Account>())).Returns(transactions);
            var service = new TransactionService(repository.Object);

            service.Transfer(account, counterAccount, 2000);

            // Test passes if repository.CreateTransaction is not called
        }

        [TestCase(AccountTypes.Checking, AccountTypes.Checking)]
        [TestCase(AccountTypes.Checking, AccountTypes.IndividualInvestment)]
        [TestCase(AccountTypes.Checking, AccountTypes.CorporateInvestment)]
        [TestCase(AccountTypes.CorporateInvestment, AccountTypes.Checking)]
        [TestCase(AccountTypes.CorporateInvestment, AccountTypes.IndividualInvestment)]
        [TestCase(AccountTypes.CorporateInvestment, AccountTypes.CorporateInvestment)]
        [TestCase(AccountTypes.IndividualInvestment, AccountTypes.Checking)]
        [TestCase(AccountTypes.IndividualInvestment, AccountTypes.IndividualInvestment)]
        [TestCase(AccountTypes.IndividualInvestment, AccountTypes.CorporateInvestment)]
        public void AccountCanTransferToAnyTypeOfAccount(AccountTypes account1Type, AccountTypes account2Type)
        {
            var account = new Account()
            {
                Id = 1
            };
            var counterAccount = new Account()
            {
                Id = 2
            };

            var transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    AccountId = account.Id,
                    Amount = 1000,
                    TransactionType = TransactionTypes.Debit,
                    CreatedDate = DateTimeOffset.Parse("1/1/2020")
                }
            };

            var repository = new Mock<ITransactionRepository>();
            repository.Setup(x => x.GetTransactions(It.IsAny<Account>())).Returns(transactions);
            var service = new TransactionService(repository.Object);

            service.Transfer(account, counterAccount, 1);

            repository.Verify(x => x.CreateTransaction(It.IsAny<Transaction>()));
        }
    }
}
