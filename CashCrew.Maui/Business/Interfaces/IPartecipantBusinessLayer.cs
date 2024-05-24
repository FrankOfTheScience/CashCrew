namespace CashCrew.Maui.Business.Interfaces
{
    public interface IPartecipantBusinessLayer
    {
        Task<IEnumerable<Partecipant>> FetchPartecipantAsync();
        Task<Partecipant> FetchPartecipantByNameAsync(string name);
        Task<bool> AddNewPartecipantAsync(Partecipant Partecipant);
        Task<bool> EditPartecipantAsync(Partecipant Partecipant);
        Task<bool> RemovePartecipantAsync(string name);
    }
}
