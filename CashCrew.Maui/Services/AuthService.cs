namespace CashCrew.Maui.Services
{
    public class AuthService
    {
        private readonly IPreferences _preferences;
        private readonly IAuthBusinessLayer _authBusinessLayer;
        public AuthService(IAuthBusinessLayer authBusinessLayer)
        {
            _preferences = Preferences.Default;
            _authBusinessLayer = authBusinessLayer;
        }

        public bool IsSignedIn => _preferences.ContainsKey(AppConstants.LoggedInKey);

        public async Task SignUp(SignUpDTO model)
        {
            var user = new Partecipant
            {
                Name = model.Name,
                Surname = model.Surname,
                Username = model.Username,
                Password = model.Password
            };
        }
        public void SignIn(SignInDTO model)
        {
            _preferences.Set(AppConstants.LoggedInKey, true);
        }

        public void SignOut()
        {
            _preferences.Remove(AppConstants.LoggedInKey);
        }
    }
}
