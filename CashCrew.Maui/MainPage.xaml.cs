namespace CashCrew.Maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage(AppViewModel appViewModel)
        {
            InitializeComponent();
            BindingContext = appViewModel;
        }
    }
}
