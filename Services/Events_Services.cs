﻿

using EventsApi.Classes;

namespace EventsApi.Services
{
    public interface IEvents_Services
    {
        public Task<List<Event>> GetAll(int pageNumber, CancellationToken Token);
        public Task<bool> AcceptInvitation(string Eventid, int participantId);

        public bool DeclineInvitation(int Eventid, CancellationToken token);

        public List<Event> CheckStatus(int Eventid);

        public Task<bool> SendInvite(Mail request);
    }
}
