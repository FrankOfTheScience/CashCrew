using CashCrew.Data.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;

namespace CashCrew.Maui.Model
{
    public class Trip
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Location { get; set; }

        [Required, MaxLength(30)]
        public string CategoryImage { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public TripStatus Status { get; set; } = TripStatus.Planned;
        public IEnumerable<Partecipant> Partecipants { get; set; } = new List<Partecipant>();
    }

    public enum TripStatus
    {
        Planned = 0,
        OnGoing = 1,
        Completed = 2,
        Cancelled = -1
    }
}
