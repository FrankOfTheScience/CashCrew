using CashCrew.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashCrew.Maui.Model
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string CategoryImage { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public TripStatus Status { get; set; }
        public IEnumerable<Partecipant> Partecipants { get; set; }
    }

    public enum TripStatus
    {
        Planned = 0,
        OnGoing = 1,
        Completed = 2,
        Cancelled = -1
    }
}
