using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LunchSystem.Models
{
    public class Order
    {
        public int OrderId;

        [Required]
        public string MemberName;

        [Required]
        public string Meal;

        [Required]
        public int Cost;

        public DateTime CreatedOn;
        public DateTime LastModifiedOn;

    }
}