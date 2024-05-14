using CashCrew.Maui.Business.Interfaces;
using CashCrew.Maui.Repository.Interfaces;

namespace CashCrew.Maui.Business
{
    public class TripBusinessLayer : ITripBusinessLayer
    {
        private readonly ITripRepository _tripRepository;
        public TripBusinessLayer(ITripRepository tripRepository)
        {
            this._tripRepository = tripRepository;
        }
        public async Task<bool> AddNewTripAsync(Trip trip)
        {
            try
            {
                if (trip is null)
                    throw new ArgumentNullException(nameof(trip));

                if (await this._tripRepository.CreateAsync(trip))
                    throw new Exception();
                return true;
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }

        public async Task<IEnumerable<Trip>> FetchTripAsync()
        {
            try
            {
                return await this._tripRepository.GetAllAsync();
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }

        public async Task<Trip> FetchTripByNameAsync(string name)
        {
            try
            {
                return await this._tripRepository.GetByNameAsync(name);
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }
    }
}
