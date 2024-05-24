namespace CashCrew.Maui.Business
{
    public class LocationCategoryBusinessLayer : ILocationCategoryBusinessLayer
    {
        private readonly LocationCategoryRepository _locationCategoryRepository;
        public LocationCategoryBusinessLayer(LocationCategoryRepository locationCategoryRepository)
            => _locationCategoryRepository = locationCategoryRepository;
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
