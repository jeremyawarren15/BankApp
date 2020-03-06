using BankApp.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankApp.Data.Models
{
    public class BankContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=c:/bankapp/bank.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var tom = new User()
            {
                Id = 1,
                FirstName = "Tom",
                LastName = "Cruise"
            };

            var bob = new User()
            {
                Id = 2,
                FirstName = "Bob",
                LastName = "Ross"
            };

            modelBuilder.Entity<User>().HasData(tom, bob);

            var accounts = new List<Account>()
            {
                new Account()
                {
                    Id = 1,
                    AccountHolderId = 1,
                    AccountType = AccountTypes.IndividualInvestment,
                    PIN = "1234"
                },
                new Account()
                {
                    Id = 2,
                    AccountHolderId = 1,
                    AccountType = AccountTypes.Checking,
                    PIN = "4321"
                },
                new Account()
                {
                    Id = 3,
                    AccountHolderId = 2,
                    AccountType = AccountTypes.IndividualInvestment,
                    PIN = "1234"
                },
                new Account()
                {
                    Id = 4,
                    AccountHolderId = 2,
                    AccountType = AccountTypes.Checking,
                    PIN = "4321"
                }
            };

            modelBuilder.Entity<Account>().HasData(accounts);

            var startingBalances = new List<Transaction>()
            {
                new Transaction()
                {
                    Id = 1,
                    AccountId = 1,
                    Amount = 2000,
                    TransactionType = TransactionTypes.Debit
                },
                new Transaction()
                {
                    Id = 2,
                    AccountId = 2,
                    Amount = 2000,
                    TransactionType = TransactionTypes.Debit
                },
                new Transaction()
                {
                    Id = 3,
                    AccountId = 3,
                    Amount = 2000,
                    TransactionType = TransactionTypes.Debit
                },
                new Transaction()
                {
                    Id = 4,
                    AccountId = 4,
                    Amount = 2000,
                    TransactionType = TransactionTypes.Debit
                },
            };

            modelBuilder.Entity<Transaction>().HasData(startingBalances);
        }
   }
}
