﻿using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SampleDesktop.Client.Presentation.Shell.Contracts.ViewModels
{
    public interface ILoginViewModel : INotifyPropertyChanged, IDisposable
    {
        ICommand LoginCommand { get; }
        ICommand LoginCancelCommand { get; }
        string UserName { get; set; }
        string Password { get; set; }
        bool IsActive { get; }
        string LoginFailureCause { get; }
        event EventHandler LoggedInSuccessfully;
    }
}