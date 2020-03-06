using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankApp.Data.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string PIN { get; set; }

        [Required]
        public AccountTypes AccountType { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset? ModifiedDate { get; set; }

        public int AccountHolderId { get; set; }
        public User AccountHolder { get; set; }

        [InverseProperty("Account")]
        public ICollection<Transaction> Transactions { get; set; }
    }
}
