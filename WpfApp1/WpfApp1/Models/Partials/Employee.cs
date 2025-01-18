using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public partial class Employee
    {
        public string DeparPosition { get => $"{Position.Department.Name} - {Position.Name}"; }
        public string FullName { get => $"{Surname} {Name} {Patronic}"; }
        public string PhoneEmaal { get => $"{WorkPhone} {Email}";}
    }
}
