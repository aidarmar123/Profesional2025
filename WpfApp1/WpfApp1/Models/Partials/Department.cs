using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Services;

namespace WpfApp1.Models
{
    public partial class Department
    {
        [JsonIgnore]
        public Department ParentDepart { get=>DbContext.Departments.FirstOrDefault(x=>x.Id == ParentDepartmentId); }
        [JsonIgnore]
        public List<Department> ChildDepart { get=>DbContext.Departments.Where(x=>x.ParentDepartmentId == Id).ToList(); }
    }
}
