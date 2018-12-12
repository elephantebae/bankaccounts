using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankaccounts.Models
{
    public class Transactions
    {
        public Transactions()
        {
        }

        [Key]
        public int TransactionId {get;set;}

        public int Amount {get;set;}

        public DateTime CreatedAt {get;set;}

        public int UserId {get;set;}

        public User Transactor {get;set;}
    }
}