using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ParkingRegistry.ApplicationCore.Extensions;
using ParkingRegistry.ApplicationCore.Interfaces;
using ParkingRegistry.Infrastructure.Data;
using ParkingRegistry.Infrastructure.Servies.Exporters;
using ParkingRegistry.Infrastructure.WPF.Listeners;
using ParkingRegistry.WPF.ViewModels;
using ParkingRegistry.WPF.Views;
using System;
using System.Windows;

namespace ParkingRegistry.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;
        public App()
        {
            _host = CreateHostBuilder().Build();
            var loggerFactory = _host.Services.GetRequiredService<ILoggerFactory>();
            var catalogContext = _host.Services.GetRequiredService<ApplicationDbContext>();
            ApplicationDbContextSeed.Seed(catalogContext, loggerFactory);
        }
        public static IHostBuilder CreateHostBuilder()
        {
            return new HostBuilder()
                .ConfigureLogging(logging =>
                    {
                        logging.AddConsole();
                    })
                .ConfigureAppConfiguration((context, configurationBuilder) =>
                {
                    configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                    configurationBuilder.AddJsonFile("appsettings.json", optional: false);
                })
                .ConfigureServices((context, services) =>
                {
                    var loggerFactory = LoggerFactory.Create(builder =>
                    {
                        builder.AddFilter((category, level) =>
                                 category == DbLoggerCategory.Database.Command.Name
                                  && level == LogLevel.Information);

                    });
                    // services.AddDbContext<ApplicationContext>(c => c.UseInMemoryDatabase("Catalog"));
                    services.AddDbContext<ApplicationDbContext>(c => 
                        c.EnableSensitiveDataLogging()
                         .UseSqlServer(context.Configuration.GetConnectionString("ApplicationDbContext")));

                    typeof(CSVExporter).Assembly.GetTypesAssignableFrom<IExporter>().ForEach((t) =>
                    {
                        services.AddTransient(typeof(IExporter), t);
                    });
                    services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
                    services.AddSingleton<ParkingList>();
                    services.AddSingleton<ParkingListViewModel>();
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<ISnackbarMessageQueue, SnackbarMessageQueue>();
                });
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
            BindingErrorListener.Attach();
            var mainWindow = _host.Services.GetService<MainWindow>();
            mainWindow.Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
