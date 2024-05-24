
namespace CashCrew.Maui.Business
{
    public class AuthBusinessLayer : IAuthBusinessLayer
    {
        private readonly AuthRepository _authRepository;
        public AuthBusinessLayer(AuthRepository authRepository)
            => _authRepository = authRepository;

        public Task<bool> SignIn(Partecipant partecipant)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SignUp(Partecipant partecipant)
        {
            throw new NotImplementedException();
        }
    }
}
