using SampleDesktop.Client.Model.Contracts;

namespace SampleDesktop.Client.Model.Shared
{
    public static class UserContext
    {
        public static IUser Current { get; set; }
    }
}
