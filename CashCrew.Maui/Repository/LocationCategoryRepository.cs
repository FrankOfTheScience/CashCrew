using CashCrew.Data.Models;
using CashCrew.Maui.Repository.Interfaces;
using MAUISql.Data;

namespace CashCrew.Maui.Repository
{
    public class LocationCategoryRepository : ICrudRepository<LocationCategory, LocationCategory>
    {
        private readonly DatabaseContext _dbContext;
        public LocationCategoryRepository(DatabaseContext dbContext)
            => _dbContext = dbContext;

        public Task<bool> CreateAsync(LocationCategory newObject)
            => throw new InvalidOperationException("The CREATE method is not allowd on LocationCategory entity");

        public Task<bool> DeleteAsync(int id)
            => throw new InvalidOperationException("The DELETE method is not allowd on LocationCategory entity");

        public async Task<IEnumerable<LocationCategory>> GetAllAsync()
            => await _dbContext.GetAllAsync<LocationCategory>();

        public async Task<LocationCategory> GetAsync(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
                return null;
            return await _dbContext.GetItemByKeyAsync<LocationCategory>(id);
        }

        public async Task<LocationCategory> GetByIdAsync(int id)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            return await _dbContext.GetItemByKeyAsync<LocationCategory>(id);
        }

        public async Task<LocationCategory> GetByNameAsync(string tripName)
        {
            if (string.IsNullOrWhiteSpace(tripName))
                throw new ArgumentNullException(nameof(tripName));
            var trip = await _dbContext.GetFileteredAsync<LocationCategory>(x => x.Name.Equals(tripName, StringComparison.OrdinalIgnoreCase));
            return trip.FirstOrDefault();
        }


        public Task<bool> UpdateAsync(LocationCategory objectToUpdate, int id)
           => throw new InvalidOperationException("The UPDATE method is not allowd on LocationCategory entity");
    }
}
