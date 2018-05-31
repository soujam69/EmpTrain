using Caliburn.Micro;
using Employee_Training.Helpers;
using Employee_Training.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Employee_Training.ViewModels
{
    public class MassTrainViewModel : Screen
    {
        public MassTrainViewModel()
        {
            GetDepartments();
            GetEmployees();
        }
        
        #region Date Info
        public bool CanAquiredDatePick
        {
            get
            {
              return true;
            }
        }

        public void AquiredDatePick()
        {
            //Blank on purpose
        }

        private DateTime? _AquiredDate;

        public DateTime? AquiredDate
        {
            get { return _AquiredDate; }
            set
            {
                _AquiredDate = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanReset);
            }
        }
        #endregion

        #region Employee Search
        private BindableCollection<EmployeeModel> _AvailableEmployees;

        public BindableCollection<EmployeeModel> AvailableEmployees
        {
            get { return _AvailableEmployees; ; }
            set { _AvailableEmployees = value; }
        }

        private EmployeeModel _SelectedEmployeeToAdd;

        public EmployeeModel SelectedEmployeeToAdd
        {
            get { return _SelectedEmployeeToAdd; }
            set
            {
                _SelectedEmployeeToAdd = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanAddEmployee);
            }
        }

        private BindableCollection<EmployeeModel> _SelectedEmployees = new BindableCollection<EmployeeModel>();

        public BindableCollection<EmployeeModel> SelectedEmployees
        {
            get { return _SelectedEmployees; }
            set { _SelectedEmployees = value; }
        }

        private EmployeeModel _SelectedEmployeeToRemove;

        public EmployeeModel SelectedEmployeeToRemove
        {
            get { return _SelectedEmployeeToRemove; }
            set
            {
                _SelectedEmployeeToRemove = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanRemoveEmployee);
            }
        }

        public bool CanAddEmployee
        {
            get
            {
                return SelectedEmployeeToAdd != null;
            }
        }

        public void AddEmployee()
        {
            foreach (var item in AvailableEmployees.Where(x => x.IsSelected).Reverse())
            {
                SelectedEmployeeToAdd.IsSelected = false;
                SelectedEmployees.Add(SelectedEmployeeToAdd);
                AvailableEmployees.Remove(SelectedEmployeeToAdd);             
            }
            NotifyOfPropertyChange(() => SelectedEmployees);
            NotifyOfPropertyChange(() => AvailableEmployees);
            NotifyOfPropertyChange(() => CanSave);
            NotifyOfPropertyChange(() => CanReset);
            SortEmployees(SelectedEmployees);
            SortEmployees(AvailableEmployees);
        }

        public bool CanRemoveEmployee
        {
            get
            {
                return SelectedEmployeeToRemove != null;
            }
        }

        public void RemoveEmployee()
        {
            foreach (var item in SelectedEmployees.Where(x => x.IsSelected).Reverse())
            {
                SelectedEmployeeToRemove.IsSelected = false;
                AvailableEmployees.Add(SelectedEmployeeToRemove);
                SelectedEmployees.Remove(SelectedEmployeeToRemove);  
            }
            NotifyOfPropertyChange(() => SelectedEmployees);
            NotifyOfPropertyChange(() => AvailableEmployees);
            NotifyOfPropertyChange(() => CanSave);
            NotifyOfPropertyChange(() => CanReset);
            SortEmployees(SelectedEmployees);
            SortEmployees(AvailableEmployees);
        }

        public void GetEmployees()
        {
            AvailableEmployees = new BindableCollection<EmployeeModel>(GlobalConfig.Connection.GetAllEmployees());
            NotifyOfPropertyChange(() => AvailableEmployees);
        }
        #endregion

        #region Department Search
        private BindableCollection<DepartmentModel> _AvailableDepartments;

        public BindableCollection<DepartmentModel> AvailableDepartments
        {
            get { return _AvailableDepartments; ; }
            set { _AvailableDepartments = value; }
        }

        private DepartmentModel _SelectedDepartment;

        public DepartmentModel SelectedDepartment
        {
            get { return _SelectedDepartment; }
            set
            {
                _SelectedDepartment = value;              
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanReset);
                if (value != null)
                {  
                  GetFunctions(SelectedDepartment.Id);    
                }    
            }
        }

        public void GetDepartments()
        {
            AvailableDepartments = new BindableCollection<DepartmentModel>(GlobalConfig.Connection.GetAllDepartments());
            NotifyOfPropertyChange(() => AvailableDepartments);
        }
        #endregion

        #region Function Search
        private BindableCollection<FunctionModel> _AvailableFunctions = new BindableCollection<FunctionModel>();

        public BindableCollection<FunctionModel> AvailableFunctions
        {
            get { return _AvailableFunctions; ; }
            set { _AvailableFunctions = value; }
        }

        private FunctionModel _SelectedFunction;

        public FunctionModel SelectedFunction
        {
            get { return _SelectedFunction; }
            set
            {
                _SelectedFunction = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        public void GetFunctions(int deptId)
        {
            AvailableFunctions = new BindableCollection<FunctionModel>(GlobalConfig.Connection.GetDeptFunctions(deptId));
            NotifyOfPropertyChange(() => AvailableFunctions);
        }
        #endregion

        #region Notes
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
        #endregion

        #region Reset
        public bool CanReset
        {
            get
            {
                if (AquiredDate != null ||
                     SelectedEmployees.Count > 0 || SelectedDepartment != null || SelectedFunction != null)
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
            AquiredDate = null;
            SelectedEmployees.Clear();
            SelectedDepartment = null;
            SelectedFunction = null;
            AvailableFunctions.Clear();
            NotifyOfPropertyChange(() => CanSave);
            NotifyOfPropertyChange(() => CanReset);
        }
        #endregion

        #region Save
        public bool CanSave
        {
            get
            {
                if (AquiredDate != null &&
                    SelectedEmployees.Count > 0 && SelectedDepartment != null && SelectedFunction != null)
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
            TrainingModel tm = new TrainingModel();

            foreach (var item in SelectedEmployees)
            {
                tm.EmpId = item.Id;
                tm.AquiredDate = AquiredDate;
                tm.DeptId = SelectedFunction.DeptId;
                tm.FunctId = SelectedFunction.Id;
                tm.Notes = Notes;
                tm = GlobalConfig.Connection.CreateTraining(tm);
            }
            EventAggregationProvider.OutTurnEventAggregator.PublishOnUIThread(new TrainingModel());
            base.TryClose();
        }

        public void Cancel()
        {
            EventAggregationProvider.OutTurnEventAggregator.PublishOnUIThread(new TrainingModel());
            base.TryClose();
        }
        #endregion 

        #region Sort Employees
        //Property for storing sorted rollstands
        private ICollectionView _SortedEmployees;

        public ICollectionView SortedEmployees
        {
            get { return _SortedEmployees; }
            set
            {
                _SortedEmployees = value;
                NotifyOfPropertyChange();
            }
        }

        //Sorts Employees by LastName in Ascending order
        public void SortEmployees(BindableCollection<EmployeeModel> bc)
        {
            SortedEmployees = CollectionViewSource.GetDefaultView(bc);
            SortedEmployees.SortDescriptions.Add(new SortDescription("LastName", ListSortDirection.Ascending));
        }
        #endregion
    }
}
