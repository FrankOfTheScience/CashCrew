using CashCrew.Data.Models;

namespace CashCrew.Maui.Business.Interfaces
{
    public interface ILocationCategoryBusinessLayer
    {
        Task<IEnumerable<LocationCategory>> FetchLocationCategoriesAsync();
        Task<LocationCategory> FetchLocationCategoryByIdAsync(string id);
    }
}
