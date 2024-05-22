using CashCrew.Data.Models;
using CashCrew.Maui.Repository.Interfaces;
using MAUISql.Data;

namespace CashCrew.Maui.Repository
{
    public class PartecipantRepository : ICrudRepository<Partecipant, Partecipant>
    {
        private readonly DatabaseContext _dbContext;
        public PartecipantRepository(DatabaseContext dbContext)
            => _dbContext = dbContext;

        public async Task<bool> CreateAsync(Partecipant newPartecipant)
        {
            if (newPartecipant is null)
                throw new ArgumentNullException(nameof(newPartecipant));
            return await _dbContext.AddItemAsync(newPartecipant);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            return await _dbContext.DeleteItemByKeyAsync<Partecipant>(id);
        }

        public async Task<IEnumerable<Partecipant>> GetAllAsync()
            => await _dbContext.GetAllAsync<Partecipant>();

        public async Task<Partecipant> GetByIdAsync(int id)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            return await _dbContext.GetItemByKeyAsync<Partecipant>(id);
        }

        public async Task<Partecipant> GetByNameAsync(string PartecipantName)
        {
            if (string.IsNullOrWhiteSpace(PartecipantName))
                throw new ArgumentNullException(nameof(PartecipantName));
            var Partecipant = await _dbContext.GetFileteredAsync<Partecipant>(x => x.Name.Equals(PartecipantName, StringComparison.OrdinalIgnoreCase));
            return Partecipant.FirstOrDefault();
        }

        public async Task<bool> UpdateAsync(Partecipant Partecipant, int id)
        {
            if (id == 0)
                return false;
            var PartecipantToUpdate = await _dbContext.GetItemByKeyAsync<Partecipant>(id);
            if (PartecipantToUpdate is null)
                return false;
            return await _dbContext.UpdateItemAsync<Partecipant>(PartecipantToUpdate);
        }
    }
}
