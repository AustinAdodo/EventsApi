using EventsApi.Classes;
using EventsApi.Services;

namespace EventsApi.Repositories
{
    public class Participants_Repository : IParticipants_Services
    {
        public bool ChangeStatus(int Eventid, string participantId)
        {
            throw new NotImplementedException();
        }

        public bool GetStatus(int Eventid, string participantId)
        {
            throw new NotImplementedException();
        }

        public List<Participant> ListActiveParticipants(int Eventid)
        {
            throw new NotImplementedException();
        }

        public List<Participant> ListParticipants()
        {
            throw new NotImplementedException();
        }
    }
}
