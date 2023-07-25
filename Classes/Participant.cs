namespace EventsApi.Classes
{
    public class Participant
    {
        public string name { get; set; }
        public int id { get; set; }
        public List<string> BookedEvents { get; internal set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int status { get; set; }
    }
}