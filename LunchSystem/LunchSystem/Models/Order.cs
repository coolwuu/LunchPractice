using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LunchSystem.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public string MemberName { get; set; }

        [Required]
        public string Meal { get; set; }

        [Required]
        public int Cost { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastModifiedOn { get; set; }

    }
}