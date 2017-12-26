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