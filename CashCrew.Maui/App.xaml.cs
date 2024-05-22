namespace CashCrew.Maui
{
    public partial class App : Application
    {
        private readonly SeedDataService _seedDataService;
        private readonly AppViewModel _appViewModel;

        public App(SeedDataService seedDataService, AppViewModel appViewModel)
        {
            InitializeComponent();

            _seedDataService = seedDataService;
            _appViewModel = appViewModel;

            MainPage = new MainPage(_appViewModel);
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await _seedDataService.SeedDataAsync();
        }
    }
}
