using System.ComponentModel.DataAnnotations;

namespace LunchSystem
{
    public class OrdersSummary
    {
        [Required] public string Meal;
        [Required] public int Count;
        [Required] public int Total;

    }
}