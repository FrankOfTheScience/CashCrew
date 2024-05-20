using CashCrew.Maui.Business.Interfaces;

namespace CashCrew.Maui.Services
{
    public class TripService
    {
        private readonly ITripBusinessLayer _tripBusinessLayer;
        public TripService(ITripBusinessLayer tripBusinessLayer)
            => this._tripBusinessLayer = tripBusinessLayer;

        public async Task<bool> CreateNewTripAsync(Trip newTrip)
        {
            try
            {
                if (newTrip is null)
                    throw new ArgumentNullException(nameof(newTrip));

                if (!await _tripBusinessLayer.AddNewTripAsync(newTrip))
                    throw new Exception();
                return true;
            }
            catch (Exception ex)
            {
                //TODO: Gestire errori
                Console.WriteLine($"Error creating trip: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> UpdateExistingTripAsync(Trip editedTrip)
        {
            try
            {
                if (editedTrip is null)
                    throw new ArgumentNullException(nameof(editedTrip));

                if (!await _tripBusinessLayer.EditTripAsync(editedTrip))
                    throw new Exception();
                return true;
            }
            catch (Exception ex)
            {
                //TODO: Gestire errori
                Console.WriteLine($"Error creating trip: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> DeleteExistingTripAsync(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentNullException(nameof(name));

                if (!await _tripBusinessLayer.RemoveTripAsync(name))
                    throw new Exception();
                return true;
            }
            catch (Exception ex)
            {
                //TODO: Gestire errori
                Console.WriteLine($"Error creating trip: {ex.Message}");
                return false;
            }
        }
        public async Task<IEnumerable<TripDTO>> GetTripsAsync()
        {
            try
            {
                var trips = await _tripBusinessLayer.FetchTripAsync();

                var tripDTOs = new List<TripDTO>();
                foreach (var trip in trips)
                {
                    tripDTOs.Add(new TripDTO
                    {
                        Name = trip.Name,
                        Country = trip.Location,
                        AdventureDays = (trip.ToDate is not null && trip.FromDate is not null) ? (trip.ToDate - trip.FromDate).Value.Days : 0,
                        CrewMates = trip.Partecipants.Count()
                    });
                }
                return tripDTOs;
            }
            catch (Exception ex)
            {
                //TODO: Gestire errori
                Console.WriteLine($"Error fetching trip: {ex.Message}");
                return new List<TripDTO> { };
            }
        }
    }
}
