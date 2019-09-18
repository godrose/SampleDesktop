using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Mvvm.Commanding;
using SampleDesktop.Client.Launcher.Shared;

namespace SampleDesktop.Client.Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    partial class App
    {
        public App()
        {
            var bootstrapper =
                new AppBootstrapper()
                    .UseResolver()
                    .UseCommanding()
                    .UseShared();
            bootstrapper.Initialize();
        }
    }
}
