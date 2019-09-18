using System;
using LogoFX.Client.Mvvm.ViewModel;
using SampleDesktop.Client.Model.Contracts;
using SampleDesktop.Client.Presentation.Shell.Contracts.ViewModels;

namespace SampleDesktop.Client.Presentation.Shell.ViewModels
{   
    public sealed class EventViewModel : ObjectViewModel<IEvent>, IEventViewModel
    {
        public EventViewModel(IEvent model)
            : base(model)
        {

        }

        public DateTime Time => Model.Time;

        public string Message => Model.Message;
    }
}