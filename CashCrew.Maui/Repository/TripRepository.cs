using CashCrew.Maui.Repository.Interfaces;
using MAUISql.Data;

namespace CashCrew.Maui.Repository
{
    public class TripRepository : ICrudRepository<Trip, Trip>
    {
        private readonly DatabaseContext _dbContext;
        public TripRepository(DatabaseContext dbContext)
            => _dbContext = dbContext;

        public async Task<bool> CreateAsync(Trip newTrip)
        {
            if (newTrip is null)
                throw new ArgumentNullException(nameof(newTrip));
            return await _dbContext.AddItemAsync(newTrip);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            return await _dbContext.DeleteItemByKeyAsync<Trip>(id);
        }

        public async Task<IEnumerable<Trip>> GetAllAsync()
            => await _dbContext.GetAllAsync<Trip>();

        public async Task<Trip> GetByIdAsync(int id)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            return await _dbContext.GetItemByKeyAsync<Trip>(id);
        }

        public async Task<Trip> GetByNameAsync(string tripName)
        {
            if (string.IsNullOrWhiteSpace(tripName))
                throw new ArgumentNullException(nameof(tripName));
            var trip = await _dbContext.GetFileteredAsync<Trip>(x => x.Name.Equals(tripName, StringComparison.OrdinalIgnoreCase));
            return trip.FirstOrDefault();
        }

        public async Task<bool> UpdateAsync(Trip trip, int id)
        {
            if (id == 0)
                return false;
            var tripToUpdate = await _dbContext.GetItemByKeyAsync<Trip>(id);
            if (tripToUpdate is null)
                return false;
            return await _dbContext.UpdateItemAsync<Trip>(tripToUpdate);
        }
    }
}
