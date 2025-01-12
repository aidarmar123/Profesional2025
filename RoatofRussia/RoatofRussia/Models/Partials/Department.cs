using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoatofRussia.Models
{
    public partial class Department
    {
        public List<Department> Departments
        {
            get
            {
                return App.Db.Department.Where(x=>x.ParentDepartment == this.Id).ToList();
            }
        }
        public Department ParentDepartmentClass { get => App.Db.Department.FirstOrDefault(x => x.Id == ParentDepartment); }
    }
}
