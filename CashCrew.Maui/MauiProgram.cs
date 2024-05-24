using CashCrew.Maui.Business.Interfaces;
using CashCrew.Maui.Repository.Interfaces;
using CommunityToolkit.Maui;
using MAUISql.Data;
using Microsoft.Extensions.Logging;

namespace CashCrew.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            RegisterServices(builder.Services);

            return builder.Build();
        }
        private static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<DatabaseContext>()
                    .AddSingleton<AppViewModel>()
                    .AddSingleton<MauiInterop>();

            services.AddTransient<ICrudRepository<Trip, Trip>, TripRepository>()
                    .AddTransient<ICrudRepository<LocationCategory, LocationCategory>, LocationCategoryRepository>()
                    .AddTransient<ICrudRepository<Partecipant, Partecipant>, PartecipantRepository>();

            services.AddTransient<ITripBusinessLayer, TripBusinessLayer>()
                    .AddTransient<ILocationCategoryBusinessLayer, LocationCategoryBusinessLayer>()
                    .AddTransient<IPartecipantBusinessLayer, PartecipantBusinessLayer>();

            services.AddTransient<SeedDataService>()
                    .AddTransient<TripService>()
                    .AddTransient<LocationCategoryService>()
                    .AddTransient<PartecipantService>()
                    .AddTransient<AuthService>();
        }
    }
}
