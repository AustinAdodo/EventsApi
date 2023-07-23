

using EventsApi.Classes;

namespace EventsApi.Services
{
    public interface IEvents_Services
    {
        public bool AcceptInvitation(int Eventid);

        public bool DeclineInvitation(int Eventid);

        public Task<bool> SendInvite(Mail request);
    }
}
