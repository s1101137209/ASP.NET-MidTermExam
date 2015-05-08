
using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Collections.Generic;
using System.Data;

namespace KuasCore.Dao.Impl
{
    public class EmployeeDao : GenericDao<Employee>, IEmployeeDao
    {

        override protected IRowMapper<Employee> GetRowMapper()
        {
            return new EmployeeRowMapper();
        }

        public void AddEmployee(Employee employee)
        {
            string command = @"INSERT INTO Employee (Id, Name, Age) VALUES (@Id, @Name, @Age);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id"  , DbType.String).Value = employee.Id;
            parameters.Add("Name", DbType.String).Value = employee.Name;
            parameters.Add("Age" , DbType.Int32 ).Value = employee.Age;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateEmployee(Employee employee)
        {
            string command = @"UPDATE Employee SET Name = @Name, Age = @Age WHERE Id = @Id;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id"  , DbType.String).Value = employee.Id;
            parameters.Add("Name", DbType.String).Value = employee.Name;
            parameters.Add("Age" , DbType.Int32 ).Value = employee.Age;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteEmployee(Employee employee)
        {
            string command = @"DELETE FROM Employee WHERE Id = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = employee.Id;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Employee> GetAllEmployees()
        {
            string command = @"SELECT * FROM Employee ORDER BY Id ASC";
            IList<Employee> employees = ExecuteQueryWithRowMapper(command);
            return employees;
        }

        public Employee GetEmployeeById(string id)
        {
            string command = @"SELECT * FROM Employee WHERE Id = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = id;

            IList<Employee> employees = ExecuteQueryWithRowMapper(command, parameters);
            if (employees.Count > 0)
            {
                return employees[0];
            }

            return null;
        }

    }
}
