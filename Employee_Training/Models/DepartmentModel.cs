using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Training.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public String DeptName { get; set; }

        public List<FunctionModel> Functions { get; set; } = new List<FunctionModel>();
    }
}
