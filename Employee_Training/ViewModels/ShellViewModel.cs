using Caliburn.Micro;
using Employee_Training.Helpers;
using Employee_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Training.ViewModels
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive, IHandle<TrainingModel>
    {
        public ShellViewModel()
        {
            // Initialize the database connections
            GlobalConfig.InitializeConnection();

            EventAggregationProvider.OutTurnEventAggregator.Subscribe(this);
            ActivateItem(new NewEmployeeViewModel());
        }

        private Screen _CurrentViewModel;

        public Screen CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set
            {
                _CurrentViewModel = value;
                NotifyOfPropertyChange();
            }
        }

        public int ScreenCount
        {
            get { return this.Items.Count; }
        }

        public override void ActivateItem(Screen item)
        {
            base.ActivateItem(item);
            NotifyOfPropertyChange(() => ScreenCount);
        }


#region Add Employee
        private bool _CanAddEmployee = true;

        public bool CanAddEmployee
        {
            get
            {
                return _CanAddEmployee;
            }
            set
            {
                _CanAddEmployee = value;
                NotifyOfPropertyChange();
            }
        }

        public void AddEmployee()
        {
            //if (ActiveItem != null)
            //    if (ActiveItem.DisplayName == "OutTurn.ViewModels.DailyCountViewModel")
            //    {
            //        ActiveItem.TryClose();
            //    }

            ActivateItem(new NewEmployeeViewModel());
            CanAddEmployee = false;
            CanEditEmployee = false;
            CanMassTrain = false;
            CanDeptFunc = false;
            CanOpenReports = false;
            CanExit = false;
        }
#endregion

#region Edit Employee
        private bool _CanEditEmployee = true;

        public bool CanEditEmployee
        {
            get
            {
                return _CanEditEmployee;
            }
            set
            {
                _CanEditEmployee = value;
                NotifyOfPropertyChange();
            }
        }

        public void EditEmployee()
        {
            //if (ActiveItem != null)
            //    if (ActiveItem.DisplayName == "OutTurn.ViewModels.DailyCountViewModel")
            //    {
            //        ActiveItem.TryClose();
            //    }

            //ActivateItem(new EditSearchViewModel());
            CanMassTrain = false;
            CanEditEmployee = false;
            CanOpenReports = false;
            CanExit = false;
        }
        #endregion

#region Mass Training
        private bool _CanMassTrain = true;

        public bool CanMassTrain
        {
            get
            {
                return _CanMassTrain;
            }
            set
            {
                _CanMassTrain = value;
                NotifyOfPropertyChange();
            }
        }

        public void MassTrain()
        {
            //if (ActiveItem != null)
            //    if (ActiveItem.DisplayName == "OutTurn.ViewModels.DailyCountViewModel")
            //    {
            //        ActiveItem.TryClose();
            //    }

            ActivateItem(new MassTrainViewModel());
            CanMassTrain = false;
            CanEditEmployee = false;
            CanOpenReports = false;
            CanExit = false;
        }
        #endregion

#region Dept/Funct
        private bool _CanDeptFunc = true;

        public bool CanDeptFunc
        {
            get
            {
                return _CanDeptFunc;
            }
            set
            {
                _CanDeptFunc = value;
                NotifyOfPropertyChange();
            }
        }

        public void DeptFunc()
        {
            //if (ActiveItem != null)
            //    if (ActiveItem.DisplayName == "OutTurn.ViewModels.DailyCountViewModel")
            //    {
            //        ActiveItem.TryClose();
            //    }

            ActivateItem(new DeptFunctViewModel());
            CanMassTrain = false;
            CanEditEmployee = false;
            CanOpenReports = false;
            CanExit = false;
        }
        #endregion


#region Open Reports
        private bool _CanOpenReports = true;

        public bool CanOpenReports
        {
            get
            {
                return _CanOpenReports;
            }
            set
            {
                _CanOpenReports = value;
                NotifyOfPropertyChange();
            }
        }

        public void OpenReports()
        {
            //if (ActiveItem != null)
            //    if (ActiveItem.DisplayName == "OutTurn.ViewModels.DailyCountViewModel")
            //    {
            //        ActiveItem.TryClose();
            //    }

            ActivateItem(new ReportViewModel());
            CanMassTrain = false;
            CanEditEmployee = false;
            CanOpenReports = false;
            CanExit = false;
        }
        #endregion

#region Exit
        private bool _CanExit = true;

        public bool CanExit
        {
            get
            {
                return _CanExit;
            }
            set
            {
                _CanExit = value;
                NotifyOfPropertyChange();
            }
        }

        public void Exit()
        {
            TryClose();
        }
#endregion

        public void Handle(TrainingModel message)
        {
            //ActivateItem(new DailyCountViewModel());
            CanMassTrain = true;
            CanEditEmployee = true;
            CanOpenReports = true;
            CanExit = true;
        }
    }
}
