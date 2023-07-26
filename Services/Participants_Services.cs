using EventsApi.Classes;

namespace EventsApi.Services
{
    public interface IParticipants_Services
    {
        //Get Participant Status on an Event
        public bool GetStatus(int Eventid, string participantId);
        public bool ChangeStatus(int Eventid, string participantId);

        //Get All
        public List<Participant> ListParticipants(int pageNumber, CancellationToken Token);

        //Get a Participant
        public Participant ListParticipants(string ParticipantId);

        public List<Participant> ListActiveParticipants(int Eventid);
    }
}
