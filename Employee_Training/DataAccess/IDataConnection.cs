using Employee_Training.Models;
using System;
using System.Collections.Generic;

namespace Employee_Training.DataAccess
{
    public interface IDataConnection
    {
        EmployeeModel CreateEmployee(EmployeeModel em);
        TrainingModel CreateTraining(TrainingModel tm);
        DepartmentModel CreateDepartment(DepartmentModel dm);
        FunctionModel CreateFunction(FunctionModel fm);
        List<DepartmentModel> GetAllDepartments();
        List<EmployeeModel> GetAllEmployees();
        List<EmployeeModel> GetFullEmployeeInfo();
        List<FunctionModel> GetAllFunctions();
        List<FunctionModel> GetDeptFunctions(int deptId);
        List<TitleModel> GetAllTitles();
        List<EmployeeModel> GetAllEmployees(DateTime? startDate, DateTime? endDate);
        List<DepartmentModel> GetAllDepartments(DateTime? startDate, DateTime? endDate);
        List<FunctionModel> GetAllFunctions(DateTime? startDate, DateTime? endDate);
        List<ReportResultsModel> GetReportResults(DateTime? startDate, DateTime? endDate, string employees, string departments, string functions);
    }
}
