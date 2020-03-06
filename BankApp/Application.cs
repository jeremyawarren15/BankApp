using BankApp.Contracts;
using BankApp.Contracts.ServiceContracts;
using BankApp.Data.Models;
using BankApp.Enums;
using BankApp.Menus;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class Application : IApplication
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly ITransactionService _transactionService;

        public Application(IUserService userService, IAccountService accountService, ITransactionService transactionService)
        {
            _accountService = accountService;
            _userService = userService;
            _transactionService = transactionService;
        }

        public void Run()
        {
            var login = new Login();
            var main = new MainMenu();
            var accountMenu = new AccountMenu(_transactionService, _accountService);

            User user = null;
            // Loop to get the user
            while (user == null)
            {
                var userId = login.GetUserId();
                user = _userService.GetUser(userId);

                if (user == null)
                {
                    Console.WriteLine("User does not exist. Try again.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.Clear();
            Console.WriteLine($"Welcome, {user.FirstName}!");
            //_accountService.CreateAccount(user, AccountTypes.Checking, "1234");
            var account = accountMenu.GetAccountSelection(user);
            if (account == null)
            {
                // Ends if user enters the wrong account or
                // if there are no accounts for the user
                return;
            }

            int selection = -1;
            while (selection == -1)
            {
                Console.Clear();
                selection = main.GetMenuSelection();
            }

            Console.Clear();
            switch (selection)
            {
                case (1): // Get Balance
                    Console.WriteLine(_transactionService.GetBalance(account));
                    break;
                case (2): // Withdraw 
                    accountMenu.Withdraw(account);
                    break;
                case (3): // Deposit
                    accountMenu.Deposit(account);
                    break;
                case (4): // Transfer
                    accountMenu.Transfer(account);
                    break;
            }
        }
    }
}
