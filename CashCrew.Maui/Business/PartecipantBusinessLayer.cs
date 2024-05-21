using CashCrew.Data.Models;
using CashCrew.Maui.Business.Interfaces;

namespace CashCrew.Maui.Business
{
    public class PartecipantBusinessLayer : IPartecipantBusinessLayer
    {
        private readonly IPartecipantRepository _PartecipantRepository;
        public PartecipantBusinessLayer(IPartecipantRepository PartecipantRepository)
        {
            _PartecipantRepository = PartecipantRepository;
        }
        public async Task<bool> AddNewPartecipantAsync(Partecipant Partecipant)
        {
            try
            {
                if (Partecipant is null)
                    throw new ArgumentNullException(nameof(Partecipant));

                if (await _PartecipantRepository.CreateAsync(Partecipant))
                    throw new Exception();
                return true;
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }

        public async Task<bool> EditPartecipantAsync(Partecipant Partecipant)
        {
            try
            {
                if (Partecipant is null)
                    throw new ArgumentNullException(nameof(Partecipant));

                var PartecipantToUpdate = await _PartecipantRepository.GetByNameAsync(Partecipant.Name);
                if (PartecipantToUpdate == null)
                    throw new InvalidOperationException("Partecipant not found.");

                foreach (var property in typeof(Partecipant).GetProperties())
                    if (property.CanWrite)
                        property.SetValue(PartecipantToUpdate, property.GetValue(Partecipant));

                return await _PartecipantRepository.UpdateAsync(PartecipantToUpdate, PartecipantToUpdate.Id);
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }

        public async Task<IEnumerable<Partecipant>> FetchPartecipantAsync()
        {
            try
            {
                return await _PartecipantRepository.GetAllAsync();
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }

        public async Task<Partecipant> FetchPartecipantByNameAsync(string name)
        {
            try
            {
                return await _PartecipantRepository.GetByNameAsync(name);
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }

        public async Task<bool> RemovePartecipantAsync(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentNullException(nameof(name));
                var PartecipantToDelete = await _PartecipantRepository.GetByNameAsync(name);
                if (PartecipantToDelete is null)
                    throw new InvalidOperationException("Partecipant not found.");

                return await _PartecipantRepository.DeleteAsync(PartecipantToDelete.Id);
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }
    }
}
