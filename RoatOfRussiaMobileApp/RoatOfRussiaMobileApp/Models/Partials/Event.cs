using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoatOfRussiaMobileApp.Models
{
    public partial class Event
    {
        public string DateEvent { get => DateTimeEvent.ToString("D"); }
    }
}
