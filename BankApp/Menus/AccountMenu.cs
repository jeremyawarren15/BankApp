using BankApp.Contracts.ServiceContracts;
using BankApp.Data.Models;
using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp.Menus
{
    public class AccountMenu
    {
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;

        public AccountMenu(ITransactionService transactionService, IAccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }

        public Account GetAccountSelection(User user)
        {
            var accounts = _accountService.GetAccounts(user)
                .ToList();

            if (!accounts.Any())
            {
                return null;
            }

            DisplayAccounts(accounts);
            Console.Write("Selection: ");

            var selection = Int32.Parse(Console.ReadLine());

            return accounts[selection];
        }

        public void Deposit(Account account)
        {
            Console.Write("Deposit amount: ");
            var amount = decimal.Parse(Console.ReadLine());

            var transaction = _transactionService.Deposit(account, amount);

            if (transaction == null)
            {
                Console.WriteLine("Could not complete transaction");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"${amount} deposited successfully");
        }

        public void Withdraw(Account account)
        {
            Console.Write("Withdraw amount: ");
            var amount = decimal.Parse(Console.ReadLine());

            var transaction = _transactionService.Withdraw(account, amount);

            if (transaction == null)
            {
                Console.WriteLine("Could not complete transaction");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"${amount} withdrawn successfully");
        }

        public void Transfer(Account account)
        {
            Account counterParty = null;

            while (counterParty == null)
            {
                Console.WriteLine("Counterparty account id: ");
                var counterPartyId = GetInput();
                counterParty = _accountService.GetAccount(counterPartyId);

                if (counterParty == null)
                {
                    Console.WriteLine("Account does not exist for given id. Please try again");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.Write($"Amount to transfer: ");
            var amount = decimal.Parse(Console.ReadLine());

            if (amount > 0)
            {
                var transaction = _transactionService.Transfer(account, counterParty, amount);
                if (transaction == null)
                {
                    Console.WriteLine("Transfer failed");
                    return;
                }

                Console.WriteLine($"Successfully transferred ${amount}: ");
            }
        }

        public int GetInput()
        {
            return Int32.Parse(Console.ReadLine());
        }

        private void DisplayAccounts(List<Account> accounts)
        {
            Console.WriteLine("Accounts");
            for (var i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine($"{i}. {accounts[i].Id} {GetAccountTypeString(accounts[i].AccountType)}");
            }
        }

        private string GetAccountTypeString(AccountTypes accountType)
        {
            switch (accountType)
            {
                case AccountTypes.Checking:
                    return "Checking";
                case AccountTypes.CorporateInvestment:
                    return "Corporate Investment";
                case AccountTypes.IndividualInvestment:
                    return "Individual Investment";
                default:
                    return "Unknown";
            }
        }
    }
}
