using System.ComponentModel.DataAnnotations.Schema;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;

namespace CashCrew.Maui.Data.Entities
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }

        [ForeignKey(nameof(Trip.Id))]
        public int TripId { get; set; }

        [Required, Range(0.1, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string Category { get; set; }
        public DateTime? SpentOn { get; set; }
    }
}
