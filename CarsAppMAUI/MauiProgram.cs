
using CarsAppMAUI.ViewModels;
using CommunityToolkit.Maui;
using MatuszewskiStasiak.SuperBooks.BLC;
using Microsoft.Extensions.Logging;

namespace CarsAppMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<BLC>();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<BookcollectionViewModel>(sp =>
            {
                var blc = sp.GetRequiredService<BLC>();
                return new BookcollectionViewModel(blc);
            });
            builder.Services.AddSingleton<CarsPage>();
            builder.Services.AddSingleton<BooksPage>();
            builder.Services.AddSingleton<PublishersPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
