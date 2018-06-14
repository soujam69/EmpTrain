using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Training.Models
{
    public class TrainingModel : PropertyChangedBase
    {
        public int Id { get; set; }
        public int EmpId { get; set; }

        private int _DeptId;

        public int DeptId
        {
            get { return _DeptId; }
            set
            {
                _DeptId = value;
                NotifyOfPropertyChange();
            }
        }

        private int _FunctId;

        public int FunctId
        {
            get { return _FunctId; }
            set
            {
                _FunctId = value;
                NotifyOfPropertyChange();
            }
        }

        private DateTime? _AcquiredDate;

        public DateTime? AcquiredDate
        {
            get { return _AcquiredDate; }
            set
            {
                _AcquiredDate = value;
                NotifyOfPropertyChange();
            }
        }

        private string _Status;

        public string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                NotifyOfPropertyChange();
            }
        }

        private string _Notes;

        public string Notes
        {
            get { return _Notes; }
            set
            {
                _Notes = value;
                NotifyOfPropertyChange();
            }
        }



        //public int DeptId { get; set; }
        //public int FunctId { get; set; }
        //public DateTime? AcquiredDate { get; set; }
        //public string Status { get; set; }
        //public string Notes { get; set; }
    }
}
