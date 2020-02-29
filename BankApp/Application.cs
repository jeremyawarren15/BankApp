using BankApp.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class Application
    {
        private readonly IAccountService _accountService;

        public Application(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Run()
        {
            _accountService.GetAccounts();
        }
    }
}
