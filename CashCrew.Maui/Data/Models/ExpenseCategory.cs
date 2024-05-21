using SQLite;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;


namespace CashCrew.Data.Models
{
    public class ExpenseCategory
    {
        [PrimaryKey, MaxLengthAttribute(100)]
        public string Name { get; set; }

        public ExpenseCategory(string name)
        {
            Name = name;
        }

        public ExpenseCategory() { }
    }
}
