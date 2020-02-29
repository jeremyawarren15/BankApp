using Autofac;
using BankApp.Contracts;
using BankApp.Contracts.RepositoryContracts;
using BankApp.Data.Repositories;
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

            // Register Application
            builder.RegisterType<Application>().As<IApplication>();

            // Register Services
            builder.RegisterType<AccountService>().As<IAccountService>();

            // Register Repositories
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();

            return builder.Build();
        }
    }
}
