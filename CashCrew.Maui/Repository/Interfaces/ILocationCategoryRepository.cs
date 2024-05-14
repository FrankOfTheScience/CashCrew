using CashCrew.Data.Models;

namespace CashCrew.Maui.Repository.Interfaces
{
    public interface ILocationCategoryRepository
    {
        Task<IEnumerable<LocationCategory>> GetAllAsync();
        Task<LocationCategory> GetAsync(string id);
    }
}
