using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankaccounts.Models
{
    public class User
    {
        public User()
        {
        }

        [Key]
        public int UserId {get;set;}
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName {get;set;}
        [EmailAddress]
        [Required]
        public string Email {get;set;}
        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 characters or more!")]
        public string Password {get;set; }

        [NotMapped]
        [Compare("Password", ErrorMessage="Passwords do not match!")]
        [DataType(DataType.Password)]
        public string Confirm {get;set;}
        public int Balance {get;set;}

        public List<Transactions> Transactions {get;set;}
    }
}