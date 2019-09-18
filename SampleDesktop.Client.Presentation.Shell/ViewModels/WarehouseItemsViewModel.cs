using Caliburn.Micro;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.ViewModel;
using LogoFX.Client.Mvvm.ViewModel.Services;
using SampleDesktop.Client.Model.Contracts;
using SampleDesktop.Client.Presentation.Shell.Contracts.ViewModels;

namespace SampleDesktop.Client.Presentation.Shell.ViewModels
{    
    [UsedImplicitly]
    public sealed class WarehouseItemsViewModel : PropertyChangedBase, IWarehouseItemsViewModel
    {
        private readonly IDataService _dataService;
        private readonly IViewModelCreatorService _viewModelCreatorService;

        public WarehouseItemsViewModel(
            IDataService dataService,
            IViewModelCreatorService viewModelCreatorService)
        {
            _dataService = dataService;
            _viewModelCreatorService = viewModelCreatorService;
        }

        private WrappingCollection.WithSelection _warehouseItems;
        public WrappingCollection.WithSelection Items => _warehouseItems ??= CreateWarehouseItems();

        private WrappingCollection.WithSelection CreateWarehouseItems()
        {
            var wc = new WrappingCollection.WithSelection
            {
                FactoryMethod = o => _viewModelCreatorService.CreateViewModel<IWarehouseItem, WarehouseItemViewModel>(
                    (IWarehouseItem) o)
            }.WithSource(_dataService.WarehouseItems);

            return wc;
        }
    }
}
