using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LunchSystem.Models
{
    public class RestaurantModel
    {
        public int RestaurantId { get; set; }

        [Required]
        public string RestaurantName { get; set; }

        public DateTime LastUploadDateTime { get; set; }
    }
}