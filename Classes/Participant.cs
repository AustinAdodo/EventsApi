
using Microsoft.EntityFrameworkCore;

namespace EventsApi.Classes
{
    [Index(nameof(email), IsUnique = true)]
    public class Participant
    {
        public string name { get; set; }

        [EmailAddress]
        public string email { get; set; }
        public int id { get; set; }
        public List<string> BookedEvents { get; internal set; }
        public string phone { get; set; }
        public int status { get; set; }
    }
}