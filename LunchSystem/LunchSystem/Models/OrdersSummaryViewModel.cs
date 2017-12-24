using System.ComponentModel.DataAnnotations;

namespace LunchSystem.Models
{
    public class OrdersSummaryViewModel
    {
        [Required] public string Meal { get; set; }
        [Required] public int Count { get; set; }
        [Required] public int Total { get; set; }

    }
}