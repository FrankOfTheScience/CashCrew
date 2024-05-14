using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
