using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Caliburn.Micro;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Core;
using SampleDesktop.Client.Model.Shared;
using SampleDesktop.Client.Presentation.Shell.Contracts.ViewModels;
using SampleDesktop.Client.Presentation.Shell.Properties;

namespace SampleDesktop.Client.Presentation.Shell.ViewModels
{    
    [UsedImplicitly]
    public sealed class ShellViewModel : Conductor<INotifyPropertyChanged>.Collection.OneActive, IShellViewModel
    {
        private readonly IViewModelCreatorService _viewModelCreatorService;

        public ShellViewModel(
            IViewModelCreatorService viewModelCreatorService)
        {
            _viewModelCreatorService = viewModelCreatorService;

            EventHandler strongHandler = OnLoggedInSuccessfully;
            LoginViewModel.LoggedInSuccessfully += WeakDelegate.From(strongHandler);
        }

        private IActionCommand _closeCommand;
        public ICommand CloseCommand =>
            CommandFactory.GetCommand(ref _closeCommand, () => TryClose(), () => true);

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;
                NotifyOfPropertyChange(() => IsBusy);
            }
        }

        public bool IsLoggedIn => UserContext.Current != null;

        private LoginViewModel _loginViewModel;
        public ILoginViewModel LoginViewModel => _loginViewModel ??= CreateLoginViewModel();

        private LoginViewModel CreateLoginViewModel()
        {
            return _viewModelCreatorService.CreateViewModel<LoginViewModel>();
        }

        private MainViewModel _mainViewModel;
        public IMainViewModel MainViewModel => _mainViewModel ??= CreateMainViewModel();

        private MainViewModel CreateMainViewModel()
        {
            return _viewModelCreatorService.CreateViewModel<MainViewModel>();
        }

        public override string DisplayName
        {
            get => string.Empty;
            set { }
        }

        //private async Task Close()
        //{
        //    await TaskRunner.RunAsync(() => Dispatch.Current.OnUiThread(() =>
        //    {
        //        TryClose();
        //    }));
        //}

        //protected override async void OnViewLoaded(object view)
        //{
        //    base.OnViewLoaded(view);
        //    ActivateItem(LoginViewModel);
        //    _windowManager.ShowDialog(LoginViewModel);

        //    if (UserContext.Current == null)
        //    {
        //        await Close();
        //    }
        //}

        protected override void OnActivate()
        {
            base.OnActivate();
            ActivateItem(LoginViewModel);
        }

        protected override void OnDeactivate(bool close)
        {
            if (close)
            {
                Settings.Default.Save();
            }

            base.OnDeactivate(close);
        }

        private void OnLoggedInSuccessfully(object sender, EventArgs eventArgs)
        {
            ActivateItem(MainViewModel);
        }
        public void Dispose()
        {
            _closeCommand?.Dispose();
            foreach (var item in Items.OfType<IDisposable>())
            {
                item.Dispose();
            }
        }
    }
}
