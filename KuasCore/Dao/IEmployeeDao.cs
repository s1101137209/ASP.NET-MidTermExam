using KuasCore.Models;
using System;
using System.Collections.Generic;

namespace KuasCore.Dao
{
    public interface IEmployeeDao
    {

        void AddEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

        IList<Employee> GetAllEmployees();

        Employee GetEmployeeById(string id);

    }
}
