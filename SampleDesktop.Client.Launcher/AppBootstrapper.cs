using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using SampleDesktop.Client.Launcher.Shared;
using SampleDesktop.Client.Presentation.Shell.ViewModels;
using Solid.Practices.Composition;

namespace SampleDesktop.Client.Launcher
{
    public sealed class AppBootstrapper : BootstrapperContainerBase<ExtendedSimpleContainerAdapter>
        .WithRootObject<ShellViewModel>
    {
        public AppBootstrapper()
            : base(new ExtendedSimpleContainerAdapter())
        {
        }

        public override CompositionOptions CompositionOptions => new CompositionOptions
        {
            Prefixes = Consts.Prefixes
        };
    }
}
