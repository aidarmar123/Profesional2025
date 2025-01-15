using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace RoatofRussia.Models
{
    public partial class Employee
    {
        public string DepartmentPosition { get => $"{Position.Department.Name} - {Position.Name}"; }
        public string FullName { get => $"{Surname} {Name} {Patronic}"; }
        public string PhoneEmail { get=> $"{WorkPhone} {Email}";}

        public List<Event> Events
        {
            get
            {
                return EventEmployee.Select(e => e.Event).ToList();
            }
        }
    }

}
