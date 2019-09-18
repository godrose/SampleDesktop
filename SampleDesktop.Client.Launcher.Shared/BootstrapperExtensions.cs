using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModelFactory.SimpleContainer;
using Solid.Bootstrapping;
using Solid.Core;
using Solid.Extensibility;

namespace SampleDesktop.Client.Launcher.Shared
{
    public static class BootstrapperExtensions
    {
        public static IInitializable UseShared<TBootstrapper>(
            this TBootstrapper bootstrapper)
            where TBootstrapper : class, IExtensible<TBootstrapper>, IHaveRegistrator, IInitializable =>
            bootstrapper
                .UseViewModelCreatorService()
                .UseViewModelFactory();
    }
}
