using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LunchSystem.Models
{
    public class OrderModels
    {
        public int OrderId { get; set; }

        [Required]
        public string MemberName { get; set; }

        [Required]
        public string Meal { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+",ErrorMessage = "Only digits are allowed.")]
        public int Cost { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastModifiedOn { get; set; }

    }
}