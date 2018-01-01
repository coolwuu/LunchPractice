using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LunchSystem.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 3,ErrorMessage = "Username length must between 3 to 15")]
        [RegularExpression(@"^[A-Za-z0-9\s]+",ErrorMessage = "Only alphabets, digit and space are allowed.")]
        public string RegisterUsername { get; set; }
        [Required]
        public string RegisterPassword { get; set; }
        [Required]
        [Compare("RegisterPassword",ErrorMessage = "兩次密碼輸入不一致")]
        public string VerifyPassword { get; set; }

        public string Message { get; set; }
        public void Valid()
        {
            if (string.IsNullOrEmpty(RegisterUsername) || string.IsNullOrEmpty(RegisterPassword) || string.IsNullOrEmpty(VerifyPassword))
            {
                throw new Exception("All fields cant be blank.");
            }
        }
    }
}