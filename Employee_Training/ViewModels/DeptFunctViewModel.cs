using Caliburn.Micro;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Employee_Training.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Employee_Training.ViewModels
{
    public class DeptFunctViewModel : Screen 
    {      
        #region Constructor
        public DeptFunctViewModel()
        {
            GetDepartments();
        }
        #endregion

        //public static DeptFunctViewModel Create()
        //{
        //    return ViewModelSource.Create(() => new DeptFunctViewModel());
        //}

        #region Department
        public bool CanDeptName
        {
            get
            {
                if (IsSelected == true)
                {
                    //Edit Mode
                    if (SelectedDepartment == null)
                    {
                        return false;
                    }
                    else
                        return true;
                    
                }
                else
                {
                    return true;
                }
            }
        }

        private string _DeptName;

        public string DeptName
        {
            get { return _DeptName; }
            set
            {
                _DeptName = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanDeptName);
                NotifyOfPropertyChange(() => CanDeptFunctToggle);
                NotifyOfPropertyChange(() => CanSaveAll);
                NotifyOfPropertyChange(() => CanAvailableFunctionsInitialize);
            }
        }

        public bool CanAvailableDepartmentsInitialize
        {
            get
            {
                if (IsSelected == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void AvailableDepartmentsInitialize()
        {
            //Left Blank
        }

        private BindableCollection<DepartmentModel> _AvailableDepartments;

        public BindableCollection<DepartmentModel> AvailableDepartments
        {
            get { return _AvailableDepartments; }
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
                //NotifyOfPropertyChange(() => CanSave);
                //NotifyOfPropertyChange(() => CanReset);
                if (value != null)
                {
                    GetFunctions(SelectedDepartment.Id);
                    DeptName = SelectedDepartment.DeptName;
                    NotifyOfPropertyChange(() => CanDeleteDept);
                    NotifyOfPropertyChange(() => CanDeptFunctToggle);
                    NotifyOfPropertyChange(() => CanSaveAll);
                }
            }
        }

        public void GetDepartments()
        {
            AvailableDepartments = new BindableCollection<DepartmentModel>(GlobalConfig.Connection.GetAllDepartments());
            NotifyOfPropertyChange(() => AvailableDepartments);
        }
        #endregion

        //#region Add Department Button
        //public bool CanAddDept
        //{
        //    get
        //    {
        //        if (IsSelected == false && !string.IsNullOrWhiteSpace(DeptName))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        //public void AddDept()
        //{

        //}
        //#endregion

        #region Function
        public void AddNewRow()
        {

        }


        public bool CanAvailableFunctionsInitialize
        {
            get
            {       
                if (IsSelected == true)
                {
                    //Edit Mode
                    if (SelectedDepartment !=null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    //Add Mode
                    if (!string.IsNullOrWhiteSpace(DeptName))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public void AvailableFunctionsInitialize()
        {
            NotifyOfPropertyChange(() => CanSaveAll);
        }

        private BindableCollection<FunctionModel> _AvailableFunctions = new BindableCollection<FunctionModel>();

        public BindableCollection<FunctionModel> AvailableFunctions
        {
            get { return _AvailableFunctions; }
            set { _AvailableFunctions = value; }
        }

        private BindableCollection<FunctionModel> _DeletedFunctions = new BindableCollection<FunctionModel>();

        public BindableCollection<FunctionModel> DeletedFunctions
        {
            get { return _DeletedFunctions; }
            set { _DeletedFunctions = value; }
        }

        private FunctionModel _SelectedFunction;

        public FunctionModel SelectedFunction
        {
            get { return _SelectedFunction; }
            set
            {
                _SelectedFunction = value;
                NotifyOfPropertyChange();
                //NotifyOfPropertyChange(() => CanSave);
                //NotifyOfPropertyChange(() => CanReset);
            }
        }

        public void GetFunctions(int deptId)
        {
            AvailableFunctions = new BindableCollection<FunctionModel>(GlobalConfig.Connection.GetDeptFunctions(deptId));

            //Makes a copy of the Origianal Available Functions then on Save it removes all non-deleted
            //items from the collection, leaving only items that need to be deleted 
            DeletedFunctions = new BindableCollection<FunctionModel>(AvailableFunctions);

            //ModifiedFunctions;

            NotifyOfPropertyChange(() => AvailableFunctions);
        }
        #endregion

        private string _FunctionName;

        public string FunctionName
        {
            get { return _FunctionName; }
            set { _FunctionName = value; }
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
                NotifyOfPropertyChange(() => CanSaveAll);
                NotifyOfPropertyChange(() => CanDeptName);
                //NotifyOfPropertyChange(() => CanDeleteDept);

                NotifyOfPropertyChange(() => CanAvailableDepartmentsInitialize);
                NotifyOfPropertyChange(() => CanAvailableFunctionsInitialize);
                
                DeptFunctToggle();
            }
        }

        public bool CanDeptFunctToggle
        {
            get
            {
                if (SelectedDepartment == null && string.IsNullOrWhiteSpace(DeptName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void DeptFunctToggle()
        {
            //Edit Mode
            if (IsSelected == false)
            {
                SelectedDepartment = null;
                //SelectedEmployee = null;
                //FirstName = null;
                //LastName = null;
                //Status = false;
                //HireDate = null;
                //ReviewDate = null;
                //Positions = null;
                //Trainings = null;

                //NotifyOfPropertyChange(() => SelectedEmployee);
               
            }
        }

        public void CancelDept()
        {
            if (!string.IsNullOrWhiteSpace(DeptName))
            {
                DeptName = null;
                SelectedDepartment = null;
                AvailableFunctions.Clear();
                NotifyOfPropertyChange(() => CanDeleteDept);
                NotifyOfPropertyChange(() => CanDeptFunctToggle);
                NotifyOfPropertyChange(() => CanSaveAll);
                NotifyOfPropertyChange(() => CanAvailableFunctionsInitialize);
                NotifyOfPropertyChange(() => CanDeptName);
            }

        }

        public bool CanDeleteDept
        {
            get
            {
                if (SelectedDepartment !=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void RowSelect(FunctionModel fm)
        {

        }

        public void DeleteDept()
        {
            foreach (var item in AvailableFunctions)
            {
                //Removes all non-deleted items
                DeletedFunctions.Remove(item);
                if (DeletedFunctions.Count != 0)
                {
                    //call delete function
                }

                FunctionName = item.FunctionName;
            }
        }

        public bool CanSaveAll
        {
            get
            {
                
                if (IsSelected == true)
                {
                    //Edit Mode
                    if (SelectedDepartment != null && AvailableFunctions.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    //Add Mode
                    if (!string.IsNullOrWhiteSpace(DeptName) && AvailableFunctions.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }


        public void SaveAll()
        {

        }

        public void SaveFunct()
        {
            foreach (var item in AvailableFunctions)
            {
                //Removes all non-deleted items
                DeletedFunctions.Remove(item);
                if (DeletedFunctions.Count !=0)
                {
                    //call delete function
                }
                
                FunctionName = item.FunctionName;
            }
        }
    }
}
