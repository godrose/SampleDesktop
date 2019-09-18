using System;

namespace SampleDesktop.Client.Presentation.Shell.Contracts.ViewModels
{
    public interface IEventViewModel
    {
        DateTime Time { get; }
        string Message { get; }
    }
}