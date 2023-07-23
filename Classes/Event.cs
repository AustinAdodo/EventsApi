namespace EventsApi.Classes
{
    public class Event
    {
        //$"{DateTime.Now.ToString("HHmmss")}{this.CreatorName}";
        public Event(string eventName)
        {
            EventName = eventName;
        }
        private string CreatorName { get; set; }
        private int CreatorId { get; set; }

        public string EventName { get; set; }

        public int EventId { get; set; }
        public string EventExternalId { get { return $"{DateTime.Now.ToString(@"HH\:mm\:ss\.ff")}{this.CreatorName}"; } } 
        public string EventType { get; set; } = "Personal";

        public string EventDescription { get; set; }
    }
}
