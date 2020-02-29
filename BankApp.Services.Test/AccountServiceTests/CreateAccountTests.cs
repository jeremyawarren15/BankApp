using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using BankApp.Data;
using BankApp.Enums;
using BankApp.Contracts.RepositoryContracts;

namespace BankApp.Services
{
    [TestFixture]
    public class CreateAccountTests
    {
        [Test]
        public void CreatesUserCorrectly()
        {
            var account = new Account() {
                AccountHolder = new User(),
                AccountType = AccountTypes.Checking,
                PIN = ""
            };

            var createdAccount = account;
            createdAccount.Id = 1;

            var mockRepo = new Mock<IAccountRepository>();
            mockRepo.Setup(x => x.CreateAccount(It.IsAny<Account>())).Returns(() => createdAccount);

            var service = new AccountService(mockRepo.Object);

            var result = service.CreateAccount(account.AccountHolder, account.AccountType, account.PIN);

            Assert.AreEqual(account, result);
            Assert.AreEqual(account.AccountHolder, result.AccountHolder);
            Assert.AreEqual(account.AccountType, result.AccountType);
            Assert.AreEqual(account.PIN, result.PIN);
        }
    }
}
