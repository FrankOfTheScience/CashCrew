using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashCrew.Maui.DTO
{
    public class TripDTO
    {
        public byte[]? Img { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public int CrewMates { get; set; }
        public int AdventureDays { get; set; }
    }
}
