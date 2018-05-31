using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Training.Models
{
    public class TrainingModel
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int DeptId { get; set; }
        public int FunctId { get; set; }
        public DateTime? AquiredDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}
