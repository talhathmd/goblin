using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goblin.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public string Amount { get; set; } = "";

        [Column(TypeName = "nvarchar(75)")]
        public string Note { get; set; } = "";

        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string? CategoryTitleWithIcon { get { return Category == null ? "" : Category.Icon + "  " + Category.Title; } }

        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                if (decimal.TryParse(Amount, out var parsedAmount))
                {
                    return ((Category == null || Category.Type == "Expense") ? "- " : "+ ") + parsedAmount.ToString("C");
                }
                return Amount;
            }
        }


    }
}
