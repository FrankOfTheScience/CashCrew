using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashCrew.Data.Models
{
    public class Expense
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int TripId { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime? SpentOn { get; set; }
    }
}
