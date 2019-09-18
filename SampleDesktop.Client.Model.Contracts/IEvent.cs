using System;

namespace SampleDesktop.Client.Model.Contracts
{
    public interface IEvent : IAppModel
    {
        DateTime Time { get; }
        string Message { get; }
    }
}