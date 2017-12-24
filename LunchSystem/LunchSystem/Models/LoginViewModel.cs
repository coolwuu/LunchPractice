using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LunchSystem.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please key in your username")]
        public string LoginUsername { get; set; }
        [Required(ErrorMessage = "Please key in your password")]
        public string LoginPassword { get; set; }

        public string Message { get; set; }

        public void Valid()
        {
            if (string.IsNullOrEmpty(LoginUsername) || string.IsNullOrEmpty(LoginPassword))
            {
                throw new Exception("Username and password cant be blank.");
            }
        }
    }
}