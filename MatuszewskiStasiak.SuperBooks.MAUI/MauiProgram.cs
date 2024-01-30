using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MatuszewskiStasiak.SuperBooks.MAUI.ViewModels;

namespace MatuszewskiStasiak.SuperBooks.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<BookCollectionViewModel>();
            builder.Services.AddSingleton<PublisherCollectionViewModel>();
            builder.Services.AddSingleton<BooksPage>();
            builder.Services.AddSingleton<PublishersPage>();
            builder.Services.AddSingleton<BLC.BLC>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
