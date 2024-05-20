namespace CashCrew.Maui.Business.Interfaces
{
    public interface ITripBusinessLayer
    {
        Task<IEnumerable<Trip>> FetchTripAsync();
        Task<Trip> FetchTripByNameAsync(string name);
        Task<bool> AddNewTripAsync(Trip trip);
        Task<bool> EditTripAsync(Trip trip);
        Task<bool> RemoveTripAsync(string name);
    }
}
