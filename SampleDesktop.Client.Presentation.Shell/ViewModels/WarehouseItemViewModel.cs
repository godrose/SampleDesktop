using LogoFX.Client.Mvvm.ViewModel;
using SampleDesktop.Client.Model.Contracts;
using SampleDesktop.Client.Presentation.Shell.Contracts.ViewModels;

namespace SampleDesktop.Client.Presentation.Shell.ViewModels
{    
    public sealed class WarehouseItemViewModel : ObjectViewModel<IWarehouseItem>, IWarehouseItemViewModel
    {
        public WarehouseItemViewModel(
            IWarehouseItem model) : base(model)
        {
        }        
    }
}
