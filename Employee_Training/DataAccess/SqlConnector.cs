using Dapper;
using Employee_Training.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Employee_Training.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        public DepartmentModel CreateDepartment(DepartmentModel dm)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectDB("EmpTrainingDB")))
            {
                var p = new DynamicParameters();
                //Add Department
                p.Add("@DeptName", dm.DeptName);

                //Dept Id from Database
                p.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);

                db.Execute("dbo.spDept_Insert", p, commandType: CommandType.StoredProcedure);

                dm.Id = p.Get<int>("@Id");

                foreach (FunctionModel fm in dm.Functions)
                {
                    p = new DynamicParameters();
                    p.Add("@DeptId", dm.Id);
                    p.Add("@FunctionName", fm.FunctionName);
                    p.Add("@RenewalMonths", fm.RenewalMonths);

                    //Dept Id from Database
                    p.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);

                    db.Execute("dbo.spFunct_Insert", p, commandType: CommandType.StoredProcedure);
                }
            }
            return dm;
        }

        public EmployeeModel CreateEmployee(EmployeeModel em)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectDB("EmpTrainingDB")))
            {
                var p = new DynamicParameters();
                //Employee Id from Database
                p.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);

                p.Add("@FirstName", em.FirstName);
                p.Add("@LastName", em.LastName);
                p.Add("@HireDate", em.HireDate);
                p.Add("@ReviewDate", em.ReviewDate);
                p.Add("@Status", em.Status);
                p.Add("@Notes", em.Notes);

                db.Execute("dbo.spEmployee_Insert", p, commandType: CommandType.StoredProcedure);

                em.Id = p.Get<int>("@Id");

                foreach (var item in em.Positions)
                {
                    p = new DynamicParameters();
                    p.Add("@EmpId", em.Id);
                    p.Add("@TitleId", item.TitleId);
                    p.Add("@PositionDate", item.PositionDate);

                    db.Execute("dbo.spPosition_Insert", p, commandType: CommandType.StoredProcedure);
                }

                foreach (var item in em.Trainings)
                {
                    p = new DynamicParameters();
                    p.Add("@EmpId", em.Id);
                    p.Add("@DeptId", item.DeptId);
                    p.Add("@FunctId", item.FunctId);
                    p.Add("@AcquireDate", item.AcquiredDate);
                    p.Add("@Status", item.Status);
                    p.Add("@Notes", item.Notes);

                    db.Execute("dbo.spTraining_Insert", p, commandType: CommandType.StoredProcedure);
                }
            }

            return em;
        }

        public FunctionModel CreateFunction(FunctionModel fm)
        {
            throw new NotImplementedException();
        }

        public TrainingModel CreateTraining(TrainingModel tm)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectDB("EmpTrainingDB")))
            {
                var p = new DynamicParameters();
                //Add Training
                p.Add("@EmpId", tm.EmpId);
                p.Add("@DeptId", tm.DeptId);
                p.Add("@FunctId", tm.FunctId);
                p.Add("@AcquiredDate", tm.AcquiredDate);
                p.Add("@Notes", tm.Notes);

                db.Execute("dbo.spTraining_Insert", p, commandType: CommandType.StoredProcedure);
            }
            return tm;
        }

        public List<DepartmentModel> GetAllDepartments()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectDB("EmpTrainingDB")))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var output = db.Query<DepartmentModel>("dbo.spDepartment_GetAll").ToList();
                return output;
            }
        }

        public List<DepartmentModel> GetAllDepartments(DateTime? startDate, DateTime? endDate)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> GetAllEmployees(DateTime? startDate, DateTime? endDate)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectDB("EmpTrainingDB")))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var output = db.Query<EmployeeModel>("dbo.spEmployee_GetAll").ToList();
                return output;
            }
        }

        public List<FunctionModel> GetAllFunctions()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectDB("EmpTrainingDB")))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var output = db.Query<FunctionModel>("dbo.spFunction_GetAll").ToList();
                return output;
            }
        }

        public List<FunctionModel> GetAllFunctions(DateTime? startDate, DateTime? endDate)
        {
            throw new NotImplementedException();
        }

        public List<TitleModel> GetAllTitles()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectDB("EmpTrainingDB")))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var output = db.Query<TitleModel>("dbo.spTitle_GetAll").ToList();
                return output;
            }
        }

        public List<FunctionModel> GetDeptFunctions(int deptId)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectDB("EmpTrainingDB")))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                var p = new DynamicParameters();
                p.Add("@SelectedId", deptId);

                var output = db.Query<FunctionModel>("dbo.spFunction_GetByDeptId", p, commandType: CommandType.StoredProcedure).ToList();
                return output;
            }
        }

        public List<EmployeeModel> GetFullEmployeeInfo()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectDB("EmpTrainingDB")))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                var p = new DynamicParameters();

                var output = db.Query<EmployeeModel>("dbo.spEmployee_GetAll").ToList();

                foreach (EmployeeModel employee in output)
                {
                    p.Add("@EmpId", employee.Id);
                    employee.Positions = db.Query<PositionModel>("dbo.spPosition_GetByEmpId", p, commandType: CommandType.StoredProcedure).ToList();
                    employee.Trainings = db.Query<TrainingModel>("dbo.spTraining_GetByEmpId", p, commandType: CommandType.StoredProcedure).ToList();
                }
                return output;
            }
        }

        public List<ReportResultsModel> GetReportResults(DateTime? startDate, DateTime? endDate, string employees, string departments, string functions)
        {
            throw new NotImplementedException();
        }
    }
}
