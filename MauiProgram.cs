﻿using Microsoft.Extensions.Logging;

namespace ProctorMVP {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                   fonts.AddFont("Outfit-VariableFont_wght.ttf", "Outfit-Variable");
                 // fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
             //    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
              //     fonts.AddFont("Outfit-Regular.ttf", "Outfit-Regular");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
