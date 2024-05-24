namespace CashCrew.Maui.Business
{
    public class PartecipantBusinessLayer : IPartecipantBusinessLayer
    {
        private readonly PartecipantRepository _partecipantRepository;
        public PartecipantBusinessLayer(PartecipantRepository partecipantRepository)
            => _partecipantRepository = partecipantRepository;
        public async Task<bool> AddNewPartecipantAsync(Partecipant Partecipant)
        {
            try
            {
                if (Partecipant is null)
                    throw new ArgumentNullException(nameof(Partecipant));

                if (await _partecipantRepository.CreateAsync(Partecipant))
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

                var PartecipantToUpdate = await _partecipantRepository.GetByNameAsync(Partecipant.Name);
                if (PartecipantToUpdate == null)
                    throw new InvalidOperationException("Partecipant not found.");

                foreach (var property in typeof(Partecipant).GetProperties())
                    if (property.CanWrite)
                        property.SetValue(PartecipantToUpdate, property.GetValue(Partecipant));

                return await _partecipantRepository.UpdateAsync(PartecipantToUpdate, PartecipantToUpdate.Id);
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
                return await _partecipantRepository.GetAllAsync();
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
                return await _partecipantRepository.GetByNameAsync(name);
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
                var PartecipantToDelete = await _partecipantRepository.GetByNameAsync(name);
                if (PartecipantToDelete is null)
                    throw new InvalidOperationException("Partecipant not found.");

                return await _partecipantRepository.DeleteAsync(PartecipantToDelete.Id);
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }
    }
}
