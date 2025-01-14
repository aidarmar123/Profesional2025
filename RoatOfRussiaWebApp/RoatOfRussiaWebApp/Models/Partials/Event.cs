using Newtonsoft.Json;

namespace RoatOfRussiaWebApp.Models
{
    public partial class Event
    {
        [JsonIgnore]

        public string Find
        {
            get
            {
                return " " + Name + ShortDescription + DateTimeEvent;
            }
        }
    }
}
