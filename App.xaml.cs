using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Todo_App.ViewModel;

namespace Todo_App
{

    public partial class App : Application
    {
        public App()
        {
            ServiceCollection serviceCollection = new();
            serviceCollection.ConfigureServices();


            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(
            this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
            return services;
        }
    }
}
