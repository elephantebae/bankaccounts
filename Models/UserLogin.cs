using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankaccounts.Models
{
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        public string EmailAddress {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}
    }
}