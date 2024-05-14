namespace CashCrew.Maui.Business.Interfaces
{
    public interface ITripBusinessLayer
    {
        Task<IEnumerable<Trip>> FetchTripAsync();
        Task<Trip> FetchTripByNameAsync(string name);
        Task<bool> AddNewTripAsync(Trip trip);

        //TODO: Finire di definire l'interfaccia
    }
}
