using Caliburn.Micro;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using Employee_Training.Helpers;
using Employee_Training.Models;
using System;
using System.Linq;

namespace Employee_Training.ViewModels
{
    public class NewEmployeeViewModel : Screen
    {
        LookUpEditBase Editor;

        public NewEmployeeViewModel()
        {
            //Departments = new BindableCollection<DepartmentModel>(GlobalConfig.Connection.GetAllDepartments());
            //Functions = new BindableCollection<FunctionModel>(GlobalConfig.Connection.GetAllFunctions());
            //Titles = new BindableCollection<TitleModel>(GlobalConfig.Connection.GetAllTitles());
            Departments.Add(new DepartmentModel {Id = 2, DeptName = "Fork Licensing"});
            Departments.Add(new DepartmentModel { Id = 3, DeptName = "Lab" });

            Functions.Add(new FunctionModel { Id = 3, DeptId = 2, FunctionName = "Fork", RenewalMonths = 36 });
            Functions.Add(new FunctionModel { Id = 4, DeptId = 2, FunctionName = "Clamp", RenewalMonths = 36 });
            Functions.Add(new FunctionModel { Id = 5, DeptId = 2, FunctionName = "Arial", RenewalMonths = 36 });
            Functions.Add(new FunctionModel { Id = 6, DeptId = 3, FunctionName = "Deviation", RenewalMonths = 0 });
            Functions.Add(new FunctionModel { Id = 7, DeptId = 3, FunctionName = "Approve Deviation", RenewalMonths = 0 });
            Functions.Add(new FunctionModel { Id = 8, DeptId = 3, FunctionName = "MMC", RenewalMonths = 0 });

            Titles.Add(new TitleModel { Id = 9, TitleName = "Utility" });
            Titles.Add(new TitleModel { Id = 7, TitleName = "Drum Operator" });
            Titles.Add(new TitleModel { Id = 2, TitleName = "Adhesive Room" });

            GetEmployees();
            IsSelected = true;
            NotifyOfPropertyChange(() => ModeSwitch);
        }

        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanReset);

            }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        private DateTime? _HireDate;

        public DateTime? HireDate
        {
            get { return _HireDate; }
            set
            {
                _HireDate = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private bool _Status;

        public bool Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanReset);
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
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private DateTime? _ReviewDate;

        public DateTime? ReviewDate
        {
            get { return _ReviewDate; }
            set
            {
                _ReviewDate = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private BindableCollection<DepartmentModel> _Departments = new BindableCollection<DepartmentModel>();

        public BindableCollection<DepartmentModel> Departments
        {
            get { return _Departments; }
            set { _Departments = value; }
        }

        private BindableCollection<FunctionModel> _Functions = new BindableCollection<FunctionModel>();

        public BindableCollection<FunctionModel> Functions
        {
            get { return _Functions; }
            set { _Functions = value; }
        }

        private BindableCollection<TitleModel> _Titles = new BindableCollection<TitleModel>();

        public BindableCollection<TitleModel> Titles
        {
            get { return _Titles; }
            set { _Titles = value; }
        }

        private BindableCollection<PositionModel> _Positions = new BindableCollection<PositionModel>();

        public BindableCollection<PositionModel> Positions
        {
            get { return _Positions; }
            set
            {
                _Positions = value;
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private BindableCollection<TrainingModel> _Trainings = new BindableCollection<TrainingModel>();

        public BindableCollection<TrainingModel> Trainings
        {
            get { return _Trainings; }
            set
            {
                _Trainings = value;
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        #region Employee Search
        private BindableCollection<EmployeeModel> _AvailableEmployees = new BindableCollection<EmployeeModel>();

        public BindableCollection<EmployeeModel> AvailableEmployees
        {
            get { return _AvailableEmployees; ; }
            set { _AvailableEmployees = value; }
        }

        private EmployeeModel _SelectedEmployee = new EmployeeModel();

        public EmployeeModel SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                _SelectedEmployee = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        public void GetEmployees()
        {
            //AvailableEmployees = new BindableCollection<EmployeeModel>(GlobalConfig.Connection.GetFullEmployeeInfo());
            AvailableEmployees.Add(new EmployeeModel { Id = 1, FirstName = "George", LastName = "Washington", HireDate = Convert.ToDateTime("02/27/2017"), Status= false });
            AvailableEmployees.Add(new EmployeeModel { Id = 1, FirstName = "Abraham", LastName = "Lincoln", HireDate = Convert.ToDateTime("03/29/1997"), Status = false });
            NotifyOfPropertyChange(() => AvailableEmployees);
        }

        public string ModeSwitch
        {
            get
            {
                if (IsSelected == true)
                {
                    return $"Edit Mode";
                }
                else
                {
                    return $"New Mode";
                }
            }
        }

        private bool _IsSelected;

        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => ModeSwitch);
                NotifyOfPropertyChange(() => CanSearchEmployees);
                NewEmployeeToggle();
            }
        }

        public bool CanSearchEmployees
        {
            get
            {
                return IsSelected == true;
            }
        }

        public void NewEmployeeToggle()
        {
            if (IsSelected == false)
            {
                SelectedEmployee = null;
                FirstName = null;
                LastName = null;
                Status = false;
                HireDate = null;
                ReviewDate = null;
                //Positions = null;
                //Trainings = null;

                NotifyOfPropertyChange(() => SelectedEmployee);
            }
        }

        public void SearchEmployees()
        {
            if (SelectedEmployee != null)
            {
                FirstName = SelectedEmployee.FirstName;
                LastName = SelectedEmployee.LastName;
                Status = SelectedEmployee.Status;
                HireDate = SelectedEmployee.HireDate;
                ReviewDate = SelectedEmployee.ReviewDate;
                foreach (var item in SelectedEmployee.Positions)
                {
                    Positions.Add(item);
                }
                foreach (var item in SelectedEmployee.Trainings)
                {
                    Trainings.Add(item);
                }
            }
        }
        #endregion

#region Reset
        public bool CanReset
        {
            get
            {
                if (FirstName != null || LastName != null || HireDate != null || ReviewDate != null || Status == true ||
                     Positions.Count > 0 || Trainings.Count > 0 || SelectedEmployee != null)
             
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Reset()
        {
            SelectedEmployee = null;
            FirstName = null;
            LastName = null;
            Status = false;
            HireDate = null;
            ReviewDate = null;
            Positions.Clear();
            Trainings.Clear();

            NotifyOfPropertyChange(() => CanSave);
            NotifyOfPropertyChange(() => CanReset);
        }
#endregion 

#region Save
        public bool CanSave
        {
            get
            {
                if (FirstName !=null && LastName !=null && HireDate != null && 
                    Positions.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Save()
        {
            EmployeeModel em = new EmployeeModel();
            em.FirstName = FirstName;
            em.LastName = LastName;
            em.HireDate = Convert.ToDateTime(HireDate);
            em.ReviewDate = Convert.ToDateTime(ReviewDate);
            em.Status = Status;
            em.Notes = Notes;

            foreach (var item in Positions)
            {
                em.Positions.Add(item);
            }

            foreach (var item in Trainings)
            {
                em.Trainings.Add(item);
            }
                em = GlobalConfig.Connection.CreateEmployee(em);
                //EmpId = Convert.ToInt32(em.Id);

            EventAggregationProvider.OutTurnEventAggregator.PublishOnUIThread(new TrainingModel());
            base.TryClose();
        }
        #endregion

#region Cancel
        public void Cancel()
        {
            EventAggregationProvider.OutTurnEventAggregator.PublishOnUIThread(new TrainingModel());
            base.TryClose();
        }
        #endregion 


        public void OnTableViewShownEditor(object sender, EditorEventArgs e)
        {
            if (e.Column.FieldName != "FunctId")
                return;
            Editor = e.Editor as LookUpEditBase;
            if (Editor == null)
                return;
            TableView view = (TableView)sender;
            int deptId = (int)view.Grid.GetCellValue(e.RowHandle, "DeptId");
            Editor.ItemsSource = Functions.Where(function => function.DeptId == deptId).ToList();
        }

        public void TableVieHiddenEditor(object sender, EditorEventArgs e)
        {
            if (Editor == null)
                return;
            Editor.ItemsSource = Functions;
            Editor = null;
        }

        public void TableViewCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "DeptId")
            {
                TrainingModel sd = e.Row as TrainingModel;
                sd.FunctId = -1;
            }
        }
    }
}
