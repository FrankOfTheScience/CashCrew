using CashCrew.Data.Models;
using CashCrew.Maui.Business.Interfaces;
using CashCrew.Maui.Repository.Interfaces;

namespace CashCrew.Maui.Business
{
    public class LocationCategoryBusinessLayer : ILocationCategoryBusinessLayer
    {
        private readonly ILocationCategoryRepository _locationCategoryRepository;
        public LocationCategoryBusinessLayer(ILocationCategoryRepository locationCategoryRepository)
        {
            this._locationCategoryRepository = locationCategoryRepository;
        }
        public async Task<IEnumerable<LocationCategory>> FetchLocationCategoriesAsync()
        {
            try
            {
                return await this._locationCategoryRepository.GetAllAsync();
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
                return await this._locationCategoryRepository.GetAsync(id);
            }
            catch (Exception)
            {
                //TODO: Gestire errori
                throw;
            }
        }
    }
}
