namespace CashCrew.Maui.Business.Interfaces
{
    public interface IAuthBusinessLayer
    {
        Task<bool> SignUp(Partecipant partecipant);
        Task<bool> SignIn(Partecipant partecipant);
    }
}
