using CashCrew.Maui.Business.Interfaces;

namespace CashCrew.Maui.Services
{
    public class PartecipantService
    {
        private readonly IPartecipantBusinessLayer _PartecipantBusinessLayer;
        public PartecipantService(IPartecipantBusinessLayer PartecipantBusinessLayer)
            => _PartecipantBusinessLayer = PartecipantBusinessLayer;

        public async Task<bool> CreateNewPartecipantAsync(Partecipant newPartecipant)
        {
            try
            {
                if (newPartecipant is null)
                    throw new ArgumentNullException(nameof(newPartecipant));

                if (!await _PartecipantBusinessLayer.AddNewPartecipantAsync(newPartecipant))
                    throw new Exception();
                return true;
            }
            catch (Exception ex)
            {
                //TODO: Gestire errori
                Console.WriteLine($"Error creating Partecipant: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> UpdateExistingPartecipantAsync(Partecipant editedPartecipant)
        {
            try
            {
                if (editedPartecipant is null)
                    throw new ArgumentNullException(nameof(editedPartecipant));

                if (!await _PartecipantBusinessLayer.EditPartecipantAsync(editedPartecipant))
                    throw new Exception();
                return true;
            }
            catch (Exception ex)
            {
                //TODO: Gestire errori
                Console.WriteLine($"Error creating Partecipant: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> DeleteExistingPartecipantAsync(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentNullException(nameof(name));

                if (!await _PartecipantBusinessLayer.RemovePartecipantAsync(name))
                    throw new Exception();
                return true;
            }
            catch (Exception ex)
            {
                //TODO: Gestire errori
                Console.WriteLine($"Error creating Partecipant: {ex.Message}");
                return false;
            }
        }

        // TODO: Create DTO for Partecipant
        //public async Task<IEnumerable<PartecipantDTO>> GetPartecipantsAsync()
        //{
        //    try
        //    {
        //        var Partecipants = await _PartecipantBusinessLayer.FetchPartecipantAsync();

        //        var PartecipantDTOs = new List<PartecipantDTO>();
        //        foreach (var Partecipant in Partecipants)
        //        {
        //            PartecipantDTOs.Add(new PartecipantDTO
        //            {
        //                Name = Partecipant.Name,
        //                Country = Partecipant.Location,
        //                AdventureDays = (Partecipant.ToDate is not null && Partecipant.FromDate is not null) ? (Partecipant.ToDate - Partecipant.FromDate).Value.Days : 0,
        //                CrewMates = Partecipant.Partecipants.Count()
        //            });
        //        }
        //        return PartecipantDTOs;
        //    }
        //    catch (Exception ex)
        //    {
        //        //TODO: Gestire errori
        //        Console.WriteLine($"Error fetching Partecipant: {ex.Message}");
        //        return new List<PartecipantDTO> { };
        //    }
        //}
    }
}
