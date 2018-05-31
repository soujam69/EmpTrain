using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Training.Models
{
    public class FunctionModel
    {
        public int Id { get; set; }
        public int DeptId { get; set; }
        public string FunctionName { get; set; }
        public int RenewalMonths { get; set; }
    }
}
