using CashCrew.Maui.Business.Interfaces;

namespace CashCrew.Maui.Services
{
    public class TripService
    {
        private readonly ITripBusinessLayer _tripBusinessLayer;
        public TripService(ITripBusinessLayer tripBusinessLayer)
        {
            this._tripBusinessLayer = tripBusinessLayer;
        }

        public async Task<bool> CreateNewTrip(Trip newTrip)
        {
            try
            {
                if (newTrip == null)
                    throw new ArgumentNullException(nameof(newTrip));

                await _tripBusinessLayer.AddNewTripAsync(newTrip);
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

        //TODO: Finire di implementare controller
    }
}
