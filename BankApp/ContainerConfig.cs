using Autofac;
using BankApp.Contracts;
using BankApp.Contracts.RepositoryContracts;
using BankApp.Contracts.ServiceContracts;
using BankApp.Data.Models;
using BankApp.Repositories;
using BankApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //Register Context
            builder.RegisterType<BankContext>();

            // Register Application
            builder.RegisterType<Application>().As<IApplication>();

            // Register Services
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<TransactionService>().As<ITransactionService>();

            // Register Repositories
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();
            builder.RegisterType<TransactionRepository>().As<ITransactionRepository>();

            return builder.Build();
        }
    }
}
