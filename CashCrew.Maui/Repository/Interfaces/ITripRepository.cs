using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashCrew.Maui.Repository.Interfaces
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetAllAsync();
        Task<Trip> GetByIdAsync(int id);
        Task<Trip> GetByNameAsync(string tripName);
        Task<bool> CreateAsync(Trip newTrip);
        Task<bool> UpdateAsync(Trip trip, int id);
        Task<bool> DeleteAsync(int id);
    }
}
