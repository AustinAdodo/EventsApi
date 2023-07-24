using EventsApi.Classes;

namespace EventsApi.Services
{
    public interface IParticipants_Services
    {
        public bool GetStatus(int Eventid, string participantId);
        public bool ChangeStatus(int Eventid, string participantId);
        public List<Participant> ListParticipants();
        public List<Participant> ListActiveParticipants(int Eventid);
    }
}
