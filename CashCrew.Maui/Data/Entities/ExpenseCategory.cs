using MaxLengthAttribute = SQLite.MaxLengthAttribute;


namespace CashCrew.Maui.Data.Entities
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
