using Microsoft.Extensions.Logging;
using Store.Services;
using System.IO;

namespace Store
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
                });

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Store.db");
            builder.Services.AddSingleton<DatabaseService>(s => new DatabaseService(dbPath));
            return builder.Build();
        }
    }
}
