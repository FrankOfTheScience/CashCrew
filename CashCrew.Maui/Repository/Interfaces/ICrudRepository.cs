namespace CashCrew.Maui.Repository.Interfaces
{
    public interface ICrudRepository<TInput, TOutput>
    {
        Task<IEnumerable<TOutput>> GetAllAsync();
        Task<TOutput> GetByIdAsync(int id);
        Task<TOutput> GetByNameAsync(string name);
        Task<bool> CreateAsync(TInput newObject);
        Task<bool> UpdateAsync(TInput objectToUpdate, int id);
        Task<bool> DeleteAsync(int id);
    }
}
