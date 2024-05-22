using CashCrew.Data.Models;
using CashCrew.Maui.Business.Interfaces;
using CashCrew.Maui.Repository.Interfaces;

namespace CashCrew.Maui.Business
{
    public class LocationCategoryBusinessLayer : ILocationCategoryBusinessLayer
    {
        private readonly ICrudRepository<LocationCategory, LocationCategory> _locationCategoryRepository;
        public LocationCategoryBusinessLayer(ICrudRepository<LocationCategory, LocationCategory> locationCategoryRepository)
        {
            _locationCategoryRepository = locationCategoryRepository;
        }
        public async Task<IEnumerable<LocationCategory>> FetchLocationCategoriesAsync()
        {
            try
            {
                return await _locationCategoryRepository.GetAllAsync();
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }

        public async Task<LocationCategory> FetchLocationCategoryByIdAsync(string id)
        {
            try
            {
                return await _locationCategoryRepository.GetByNameAsync(id);
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }
    }
}
