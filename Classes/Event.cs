namespace EventsApi.Classes
{
    public class Event
    {
        //$"{DateTime.Now.ToString("HHmmss")}{this.CreatorName}";
        public Event()
        {

        }
        public int EventId { get; set; }
        public string EventName { get; set; }
        private int CreatorId { get; set; }
        private string CreatorName { get; set; }

        public string Location { get; set; }

        public string EventExternalId { get { return $"{DateTime.Now.ToString(@"HH\:mm\:ss\.ff")}{this.CreatorName}"; } } 
        public string EventType { get; set; } = "Personal";

        public string EventDescription { get; set; }
        public DateTime EventStartdate { get; set; }
        public DateTime EventEnddate { get; set; }

        public string TimeZone{ get; set; }
        public TimeOnly EventTime { get; set; }
    }
}
