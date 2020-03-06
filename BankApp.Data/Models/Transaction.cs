using BankApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankApp.Data.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public TransactionTypes TransactionType { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset? ModifiedDate { get; set; }

        public int AccountId { get; set; }
        public int? CounterpartyAccountId { get; set; }

        public Account Account { get; set; }

        public Account CounterpartyAccount { get; set; }
    }
}
