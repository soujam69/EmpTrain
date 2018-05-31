using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Training.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public bool Status { get; set; }
        public string Notes { get; set; }
        public DateTime? ReviewDate { get; set; }

        public List<PositionModel> Positions { get; set; } = new List<PositionModel>();
        public List<TrainingModel> Trainings { get; set; } = new List<TrainingModel>();

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public bool IsSelected { get; set; }
    }
}
