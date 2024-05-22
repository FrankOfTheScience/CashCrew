using CashCrew.Maui.Business.Interfaces;
using CashCrew.Maui.Repository.Interfaces;

namespace CashCrew.Maui.Business
{
    public class TripBusinessLayer : ITripBusinessLayer
    {
        private readonly ICrudRepository<Trip, Trip> _tripRepository;
        public TripBusinessLayer(ICrudRepository<Trip, Trip> tripRepository)
        {
            _tripRepository = tripRepository;
        }
        public async Task<bool> AddNewTripAsync(Trip trip)
        {
            try
            {
                if (trip is null)
                    throw new ArgumentNullException(nameof(trip));

                if (await _tripRepository.CreateAsync(trip))
                    throw new Exception();
                return true;
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }

        public async Task<bool> EditTripAsync(Trip trip)
        {
            try
            {
                if (trip is null)
                    throw new ArgumentNullException(nameof(trip));

                var tripToUpdate = await _tripRepository.GetByNameAsync(trip.Name);
                if (tripToUpdate == null)
                    throw new InvalidOperationException("Trip not found.");

                foreach (var property in typeof(Trip).GetProperties())
                {
                    if (property.Name.Equals(nameof(Trip.ModifiedOn)))
                        property.SetValue(tripToUpdate, DateTime.Now);
                    else if (property.CanWrite)
                        property.SetValue(tripToUpdate, property.GetValue(trip));
                }

                return await _tripRepository.UpdateAsync(tripToUpdate, tripToUpdate.Id);
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
                return await _tripRepository.GetAllAsync();
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
                return await _tripRepository.GetByNameAsync(name);
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }

        public async Task<bool> RemoveTripAsync(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentNullException(nameof(name));
                var tripToDelete = await _tripRepository.GetByNameAsync(name);
                if (tripToDelete is null)
                    throw new InvalidOperationException("Trip not found.");

                return await _tripRepository.DeleteAsync(tripToDelete.Id);
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }
    }
}
