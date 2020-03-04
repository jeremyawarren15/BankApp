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
    }
}
