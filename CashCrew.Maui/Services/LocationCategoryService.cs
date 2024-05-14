using CashCrew.Data.Models;
using CashCrew.Maui.Business.Interfaces;

namespace CashCrew.Maui.Services
{
    public class LocationCategoryService
    {
        private readonly ILocationCategoryBusinessLayer _locationCategoryBusinessLayer;
        public LocationCategoryService(ILocationCategoryBusinessLayer locationCategoryBusinessLayer)
        {
            this._locationCategoryBusinessLayer = locationCategoryBusinessLayer;
        }

        public async Task<IEnumerable<LocationCategory>> GetAllLocationCategoriesAsync()
        {
            try
            {
                return await this._locationCategoryBusinessLayer.FetchLocationCategoriesAsync();
            }
            catch (Exception ex)
            {
                //TODO: Gestire errori
                Console.WriteLine($"Error fetching location categories: {ex.Message}");
                return new List<LocationCategory>();
            }
        }

        public async Task<LocationCategory> GetLocationCategoryByIdAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentNullException(nameof(id)); 
                return await this._locationCategoryBusinessLayer.FetchLocationCategoryByIdAsync(id);
            }
            catch (Exception ex)
            {
                //TODO: Gestire errori
                Console.WriteLine($"Error fetching location category by id: {ex.Message}");
                return new LocationCategory();
            }
        }
    }
}
