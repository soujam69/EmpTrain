using Caliburn.Micro;
using Employee_Training.Helpers;
using Employee_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Employee_Training.ViewModels
{
    public class ReportViewModel : Screen
    {
        IWindowManager manager = new WindowManager();

        #region Report Type
        private bool _BasisWeight;

        public bool BasisWeight
        {
            get { return _BasisWeight; }
            set
            {
                _BasisWeight = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => ReportTypeSelected);
                NotifyOfPropertyChange(() => CanPrint);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private bool _BurstStrength;

        public bool BurstStrength
        {
            get { return _BurstStrength; }
            set
            {
                _BurstStrength = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => ReportTypeSelected);
                NotifyOfPropertyChange(() => CanPrint);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private bool _Caliper;

        public bool Caliper
        {
            get { return _Caliper; }
            set
            {
                _Caliper = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => ReportTypeSelected);
                NotifyOfPropertyChange(() => CanPrint);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private bool _FeetPerMin;

        public bool FeetPerMin
        {
            get { return _FeetPerMin; }
            set
            {
                _FeetPerMin = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => ReportTypeSelected);
                NotifyOfPropertyChange(() => CanPrint);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private bool _MoistureContent;

        public bool MoistureContent
        {
            get { return _MoistureContent; }
            set
            {
                _MoistureContent = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => ReportTypeSelected);
                NotifyOfPropertyChange(() => CanPrint);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private bool _OutTurnForm;

        public bool OutTurnForm
        {
            get { return _OutTurnForm; }
            set
            {
                _OutTurnForm = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => ReportTypeSelected);
                NotifyOfPropertyChange(() => CanPrint);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private bool _TensileStrength;

        public bool TensileStrength
        {
            get { return _TensileStrength; }
            set
            {
                _TensileStrength = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => ReportTypeSelected);
                NotifyOfPropertyChange(() => CanPrint);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private bool _WaterImmersion;

        public bool WaterImmersion
        {
            get { return _WaterImmersion; }
            set
            {
                _WaterImmersion = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => ReportTypeSelected);
                NotifyOfPropertyChange(() => CanPrint);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private bool _ZDT;

        public bool ZDT
        {
            get { return _ZDT; }
            set
            {
                _ZDT = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => ReportTypeSelected);
                NotifyOfPropertyChange(() => CanPrint);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        public bool ReportTypeSelected
        {
            get
            {
                if (BasisWeight == true || BurstStrength == true || Caliper == true || FeetPerMin == true || MoistureContent == true || OutTurnForm == true ||
                    TensileStrength == true || WaterImmersion == true || ZDT == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string reportName;

        public string GetReportToPrint()
        {
            if (ReportTypeSelected == true)
            {
                if (BasisWeight == true)
                {
                    reportName = "EmpInfo";
                }

                if (BurstStrength == true)
                {
                    reportName = "EmpTrain";
                }
            }
            return reportName;
        }
        #endregion

        #region Date Search
        private bool _AllDates;

        public bool AllDates
        {
            get { return _AllDates; }
            set
            {
                _AllDates = value;
                NotifyOfPropertyChange();
            }
        }

        public void AllDatesChk()
        {
            if (AllDates == true)
            {
                StartDate = null;
                NotifyOfPropertyChange(() => StartDate);

                EndDate = null;
                NotifyOfPropertyChange(() => EndDate);

                NotifyOfPropertyChange(() => CanStartDatePick);
                NotifyOfPropertyChange(() => CanEndDatePick);
                RefreshCriteria();
            }
            else
            {
                NotifyOfPropertyChange(() => CanStartDatePick);
                NotifyOfPropertyChange(() => CanEndDatePick);
                NotifyOfPropertyChange(() => CanPrint);
                NotifyOfPropertyChange(() => CanReset);
                RefreshCriteria();
            }
        }

        public bool CanStartDatePick
        {
            get
            {
                if (AllDates == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void StartDatePick()
        {
            //Blank on purpose
        }

        private DateTime? _StartDate;

        public DateTime? StartDate
        {
            get { return _StartDate; }
            set
            {
                _StartDate = value;
                NotifyOfPropertyChange();
                EndDate = StartDate;
                NotifyOfPropertyChange(() => StartDate);
                NotifyOfPropertyChange(() => CanEndDatePick);
                NotifyOfPropertyChange(() => CanPrint);
                NotifyOfPropertyChange(() => CanReset);
                RefreshCriteria();
            }
        }

        public bool CanEndDatePick
        {
            get
            {
                if (AllDates == true || StartDate == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void EndDatePick()
        {
            //Blank on purpose
        }


        private DateTime? _EndDate;

        public DateTime? EndDate
        {
            get { return _EndDate; }
            set
            {
                if (value != null)
                {
                    if (value >= StartDate)
                    {
                        _EndDate = value;
                        NotifyOfPropertyChange();
                        NotifyOfPropertyChange(() => CanPrint);
                        NotifyOfPropertyChange(() => CanReset);
                        RefreshCriteria();
                    }
                    else
                    {
                        MessageBox.Show("End Date cannot be less than the Start Date!");
                        _EndDate = null;
                        NotifyOfPropertyChange(() => CanPrint);
                        NotifyOfPropertyChange(() => CanReset);
                    }
                }
                else
                {
                    _EndDate = value;
                    NotifyOfPropertyChange();
                    NotifyOfPropertyChange(() => CanPrint);
                    NotifyOfPropertyChange(() => CanReset);
                    RefreshCriteria();
                }
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

        private bool _EmployeeSelectAll = true;

        public bool EmployeeSelectAll
        {
            get { return _EmployeeSelectAll; }
            set
            {
                _EmployeeSelectAll = value;
                NotifyOfPropertyChange();

                if (EmployeeSelectAll == true)
                {
                    SelectedEmployees.Clear();
                }
            }
        }

        private bool _EmployeeSelectAny;

        public bool EmployeeSelectAny
        {
            get { return _EmployeeSelectAny; }
            set
            {
                _EmployeeSelectAny = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanEmployeesList);
                GetEmployees();
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
            SelectedEmployees.Add(SelectedEmployeeToAdd);
            AvailableEmployees.Remove(SelectedEmployeeToAdd);
            NotifyOfPropertyChange(() => SelectedEmployees);
            NotifyOfPropertyChange(() => CanPrint);
            NotifyOfPropertyChange(() => CanReset);
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
            AvailableEmployees.Add(SelectedEmployeeToRemove);
            SelectedEmployees.Remove(SelectedEmployeeToRemove);
            NotifyOfPropertyChange(() => SelectedEmployees);
            NotifyOfPropertyChange(() => CanPrint);
            NotifyOfPropertyChange(() => CanReset);
        }

        public bool CanEmployeesList
        {
            get
            {
                if (EmployeeSelectAny == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public void GetEmployees()
        {
            DateTime? startDate;
            DateTime? endDate;

            startDate = StartDate;
            endDate = EndDate;

            AvailableEmployees = new BindableCollection<EmployeeModel>(GlobalConfig.Connection.GetAllEmployees(startDate, endDate));
            NotifyOfPropertyChange(() => AvailableEmployees);
        }

        public void EmployeesList()
        {
            //Blank on purpose
        }
        #endregion

        #region Department Search
        private BindableCollection<DepartmentModel> _AvailableDepartments;

        public BindableCollection<DepartmentModel> AvailableDepartments
        {
            get { return _AvailableDepartments; ; }
            set { _AvailableDepartments = value; }
        }

        private DepartmentModel _SelectedDepartmentToAdd;

        public DepartmentModel SelectedDepartmentToAdd
        {
            get { return _SelectedDepartmentToAdd; }
            set
            {
                _SelectedDepartmentToAdd = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanAddDepartment);
            }
        }

        private BindableCollection<DepartmentModel> _SelectedDepartments = new BindableCollection<DepartmentModel>();

        public BindableCollection<DepartmentModel> SelectedDepartments
        {
            get { return _SelectedDepartments; }
            set
            {
                _SelectedDepartments = value;
            }
        }

        private DepartmentModel _SelectedDepartmentToRemove;

        public DepartmentModel SelectedDepartmentToRemove
        {
            get { return _SelectedDepartmentToRemove; }
            set
            {
                _SelectedDepartmentToRemove = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanRemoveDepartment);
            }
        }

        private bool _DepartmentSelectAll = true;

        public bool DepartmentSelectAll
        {
            get { return _DepartmentSelectAll; }
            set
            {
                _DepartmentSelectAll = value;
                NotifyOfPropertyChange();

                if (DepartmentSelectAll == true)
                {
                    SelectedDepartments.Clear();
                }
            }
        }

        private bool _DepartmentSelectAny;

        public bool DepartmentSelectAny
        {
            get { return _DepartmentSelectAny; }
            set
            {
                _DepartmentSelectAny = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanDepartmentsList);
                GetDepartments();
            }
        }

        public bool CanAddDepartment
        {
            get
            {
                return SelectedDepartmentToAdd != null;
            }
        }

        public void AddDepartment()
        {
            SelectedDepartments.Add(SelectedDepartmentToAdd);
            AvailableDepartments.Remove(SelectedDepartmentToAdd);
            NotifyOfPropertyChange(() => SelectedDepartments);
            NotifyOfPropertyChange(() => CanPrint);
            NotifyOfPropertyChange(() => CanReset);
        }

        public bool CanRemoveDepartment
        {
            get
            {
                return SelectedDepartmentToRemove != null;
            }
        }

        public void RemoveSampleNo()
        {
            AvailableDepartments.Add(SelectedDepartmentToRemove);
            SelectedDepartments.Remove(SelectedDepartmentToRemove);
            NotifyOfPropertyChange(() => SelectedDepartments);
            NotifyOfPropertyChange(() => CanPrint);
            NotifyOfPropertyChange(() => CanReset);
        }

        public bool CanDepartmentsList
        {
            get
            {
                if (DepartmentSelectAny == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void GetDepartments()
        {
            DateTime? startDate;
            DateTime? endDate;

            startDate = StartDate;
            endDate = EndDate;

            AvailableDepartments = new BindableCollection<DepartmentModel>(GlobalConfig.Connection.GetAllDepartments(startDate, endDate));
            NotifyOfPropertyChange(() => AvailableDepartments);
        }

        public void DepartmentsList()
        {
            //Blank on purpose
        }
        #endregion

        #region Function Search
        private BindableCollection<FunctionModel> _AvailableFunctions;

        public BindableCollection<FunctionModel> AvailableFunctions
        {
            get { return _AvailableFunctions; ; }
            set { _AvailableFunctions = value; }
        }

        private FunctionModel _SelectedFunctionToAdd;

        public FunctionModel SelectedFunctionToAdd
        {
            get { return _SelectedFunctionToAdd; }
            set
            {
                _SelectedFunctionToAdd = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanAddFunction);
            }
        }

        private BindableCollection<FunctionModel> _SelectedFunction = new BindableCollection<FunctionModel>();

        public BindableCollection<FunctionModel> SelectedFunctions
        {
            get { return _SelectedFunction; }
            set
            {
                _SelectedFunction = value;
                NotifyOfPropertyChange(() => CanPrint);
                NotifyOfPropertyChange(() => CanReset);
            }
        }

        private FunctionModel _SelectedFunctionToRemove;

        public FunctionModel SelectedFunctionToRemove
        {
            get { return _SelectedFunctionToRemove; }
            set
            {
                _SelectedFunctionToRemove = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanRemoveFunction);
            }
        }

        private bool _FunctionSelectAll = true;

        public bool FunctionSelectAll
        {
            get { return _FunctionSelectAll; }
            set
            {
                _FunctionSelectAll = value;
                NotifyOfPropertyChange();

                if (FunctionSelectAll == true)
                {
                    SelectedFunctions.Clear();
                }
            }
        }

        private bool _FunctionSelectAny;

        public bool FunctionSelectAny
        {
            get { return _FunctionSelectAny; }
            set
            {
                _FunctionSelectAny = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanFunctionsList);
                GetFunctions();
            }
        }

        public bool CanAddFunction
        {
            get
            {
                return SelectedFunctionToAdd != null;
            }
        }

        public void AddFunction()
        {
            SelectedFunctions.Add(SelectedFunctionToAdd);
            AvailableFunctions.Remove(SelectedFunctionToAdd);
            NotifyOfPropertyChange(() => SelectedFunctions);
            NotifyOfPropertyChange(() => CanPrint);
            NotifyOfPropertyChange(() => CanReset);
        }

        public bool CanRemoveFunction
        {
            get
            {
                return SelectedFunctionToRemove != null;
            }
        }

        public void RemoveFunction()
        {
            AvailableFunctions.Add(SelectedFunctionToRemove);
            SelectedFunctions.Remove(SelectedFunctionToRemove);
            NotifyOfPropertyChange(() => SelectedFunctions);
            NotifyOfPropertyChange(() => CanPrint);
            NotifyOfPropertyChange(() => CanReset);
        }

        public bool CanFunctionsList
        {
            get
            {
                if (FunctionSelectAny == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public void GetFunctions()
        {
            DateTime? startDate;
            DateTime? endDate;

            startDate = StartDate;
            endDate = EndDate;

            AvailableFunctions = new BindableCollection<FunctionModel>(GlobalConfig.Connection.GetAllFunctions(startDate, endDate));
            NotifyOfPropertyChange(() => AvailableFunctions);
        }

        public void FunctionsList()
        {
            //Blank on purpose
        }
        #endregion

        #region Print Info
        private BindableCollection<ReportResultsModel> _ReportResults;

        public BindableCollection<ReportResultsModel> ReportResults
        {
            get { return _ReportResults; ; }
            set { _ReportResults = value; }

        }

        public bool CanPrint
        {
            get
            {
                if ((ReportTypeSelected == true) && (AllDates == true || StartDate != null && EndDate != null ||
                    SelectedEmployees.Count > 0 || SelectedDepartments.Count > 0 || SelectedFunctions.Count > 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Print()
        {
            DateTime? startDate;
            DateTime? endDate;
            string empoloyees;
            string departments;
            string functions;

            startDate = StartDate;
            endDate = EndDate;
            empoloyees = String.Join(", ", SelectedEmployees.Select(o => o.Id));
            departments = String.Join(", ", SelectedDepartments.Select(o => o.Id));
            functions = String.Join(", ", SelectedFunctions.Select(o => o.Id));

            ReportResults = new BindableCollection<ReportResultsModel>(GlobalConfig.Connection.GetReportResults(startDate, endDate, empoloyees, departments, functions));


            //EventAggregationProvider.OutTurnEventAggregator.PublishOnUIThread(ReportResults);

            GetReportToPrint();

            manager.ShowDialog(new ReportShowViewModel(ReportResults, reportName), null, null);


        }
        #endregion

        public void RefreshCriteria()
        {
            GetEmployees();
            GetDepartments();
            GetFunctions();
        }

        public bool CanReset
        {
            get
            {
                if (ReportTypeSelected == true || AllDates == true || StartDate != null && EndDate != null ||
                     SelectedEmployees.Count > 0 || SelectedDepartments.Count > 0 || SelectedFunctions.Count > 0)
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
            BasisWeight = false;
            BurstStrength = false;
            Caliper = false;
            FeetPerMin = false;
            MoistureContent = false;
            OutTurnForm = false;
            TensileStrength = false;
            WaterImmersion = false;
            ZDT = false;

            AllDates = false;
            StartDate = null;
            EndDate = null;
            AllDatesChk();

            SelectedEmployees.Clear();
            EmployeeSelectAll = true;

            SelectedDepartments.Clear();
            DepartmentSelectAll = true;

            SelectedFunctions.Clear();
            FunctionSelectAll = true;

            NotifyOfPropertyChange(() => CanPrint);
            NotifyOfPropertyChange(() => CanReset);
        }

        public void Cancel()
        {
            //EventAggregationProvider.OutTurnEventAggregator.PublishOnUIThread(new MaxSampleNoModel());
            base.TryClose();
        }
    }
}
