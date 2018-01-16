﻿using System.ComponentModel.DataAnnotations;

namespace LunchSystem.Models
{
    public class AccountModels
    {
        [Required]
        [StringLength(50)]
        public string AccountId { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

     }
}