using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Training.Models
{
    public class PositionModel
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int TitleId { get; set; }
        public DateTime? PositionDate { get; set; }
    }
}
