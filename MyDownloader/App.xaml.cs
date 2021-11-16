using System;
using System.IO;
using System.Windows;
using Aria2Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyDownloader.Services;
using MyDownloader.ViewModels;
using MyDownloader.Views;

namespace MyDownloader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Aria2Process _process = new Aria2Process("./aria2c.exe", $"--enable-rpc=true --rpc-listen-port=6800 --save-session={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "mydownloader", "session")} --save-session-interval=10");
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .ConfigureLogging(x =>
                {
                    // x.AddSplat();
                })
                .Build();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //services.UseMicrosoftDependencyResolver();

            //var resolver = Locator.CurrentMutable;
            //resolver.InitializeSplat();
            //resolver.InitializeReactiveUI();
            //resolver.RegisterViewsForViewModels(Assembly.GetCallingAssembly());


            services.AddSingleton<MainWindow>();
            services.AddSingleton<ItemsView>();
            services.AddTransient<AddView>();

            //services.AddSingleton<IViewFor<MainWindowViewModel>, MainWindow>();
            //services.AddSingleton<IViewFor<ItemsViewModel>, ItemsView>();
            //services.AddSingleton<IViewFor<AddViewModel>, AddView>();

            // services.AddSingleton<IScreen>(x => x.GetRequiredService<MainWindowViewModel>());

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<ItemsViewModel>();
            services.AddTransient<AddViewModel>();


            //services.AddSingleton<SourceList<ItemModel>>();


            services.AddSingleton<DownloadService>();

            services.AddSingleton<IStore, JsonStore>(); 
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _host.Start();

            // _host.Services.UseMicrosoftDependencyResolver();

            _process.Start();

            _host.Services.GetRequiredService<MainWindow>().Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }

            base.OnExit(e);

            _process.Stop();
        }

    }
}
