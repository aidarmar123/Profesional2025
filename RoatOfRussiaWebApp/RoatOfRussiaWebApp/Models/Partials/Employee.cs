using System.Text.Json.Serialization;

namespace RoatOfRussiaWebApp.Models
{
    public partial class Employee
    {
        [JsonIgnore]
        public string Find
        {
            get
            {
                return Name + Surname + Patronic + WorkPhone + Email + Position.Name+" ";
            }
        }
    }
}
