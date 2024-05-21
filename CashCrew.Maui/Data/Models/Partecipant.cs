using SQLite;

namespace CashCrew.Data.Models
{
    public class Partecipant
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
