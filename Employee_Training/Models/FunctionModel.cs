using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Training.Models
{
    public class FunctionModel : PropertyChangedBase
    {
        public int Id { get; set; }
        public int DeptId { get; set; }
        //public string FunctionName { get; set; }
        //public int RenewalMonths { get; set; }
        private string _FunctionName;

        public string FunctionName
        {
            get { return _FunctionName; }
            set
            {
                _FunctionName = value;
                NotifyOfPropertyChange();
            }
        }

        private int _RenewalMonths;

        public int RenewalMonths
        {
            get { return _RenewalMonths; }
            set
            {
                _RenewalMonths = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
