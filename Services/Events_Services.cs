

using EventsApi.Classes;

namespace EventsApi.Services
{
    public interface IEvents_Services
    {
        public bool AcceptInvitation(string Eventid);

        public bool DeclineInvitation(int Eventid);

        public List<Event> CheckStatus(int Eventid);

        public Task<bool> SendInvite(Mail request);
    }
}
