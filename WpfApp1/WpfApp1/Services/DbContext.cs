using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp1.Models;

namespace WpfApp1.Services
{
    public static class DbContext
    {
       public static List<Employee> Employees;
       public static List<Department> Departments;
       public static List<Cabinet> Cabinets;
       public static List<Position> Positions;
       public static List<Material> Materials;
       public static List<Event> Events;
       public static List<EventEmployee> EventEmployees;
       public static List<TypeEvent> TypeEvents;
       public static List<StatusEvent> StatusEvents;
       public static List<PositionMaterial> PositionMaterials;
       public static List<TypeMaterial> TypeMaterials;

        public static async void InitData()
        {
            Cabinets = await NetManager.Get<List<Cabinet>>("api/Cabinets");
            Departments = await NetManager.Get<List<Department>>("api/Departments");
            Positions = await NetManager.Get<List<Position>>("api/Positions");
            Employees = await NetManager.Get<List<Employee>>("api/Employees");
            Materials = await NetManager.Get<List<Material>>("api/Materials");
            Events = await NetManager.Get<List<Event>>("api/Events");
            TypeEvents = await NetManager.Get<List<TypeEvent>>("api/TypeEvents");
            StatusEvents = await NetManager.Get<List<StatusEvent>>("api/StatusEvents");
            PositionMaterials = await NetManager.Get<List<PositionMaterial>>("api/PositionMaterials");
            TypeMaterials = await NetManager.Get<List<TypeMaterial>>("api/TypeMaterials");
            EventEmployees = await NetManager.Get<List<EventEmployee>>("api/EventEmployees");
        }
    }
}
