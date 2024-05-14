using CashCrew.Data.Models;
using CashCrew.Maui.Repository.Interfaces;
using MAUISql.Data;

namespace CashCrew.Maui.Repository
{
    public class LocationCategoryRepository : ILocationCategoryRepository
    {
        private readonly DatabaseContext _dbContext;
        public LocationCategoryRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<LocationCategory>> GetAllAsync()
            => await _dbContext.GetAllAsync<LocationCategory>();

        public async Task<LocationCategory> GetAsync(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
                return null;
            return await _dbContext.GetItemByKeyAsync<LocationCategory>(id);
        }
    }
}
