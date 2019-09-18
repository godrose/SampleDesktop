using LogoFX.Client.Mvvm.ViewModel;

namespace SampleDesktop.Client.Presentation.Shell.Contracts.ViewModels
{
    public interface IWarehouseItemsViewModel
    {
        WrappingCollection.WithSelection Items { get; }
    }
}