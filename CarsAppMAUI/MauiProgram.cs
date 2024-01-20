﻿using CarsAppMAUI.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace CarsAppMAUI
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

            builder.Services.AddSingleton<CarCollectionViewModel>();
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
