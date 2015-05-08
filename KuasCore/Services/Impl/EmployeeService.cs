using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {

        public IEmployeeDao EmployeeDao { get; set; }

        public void AddEmployee(Employee employee)
        {
            EmployeeDao.AddEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            EmployeeDao.UpdateEmployee(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            employee = EmployeeDao.GetEmployeeById(employee.Id);

            if (employee != null)
            {
                EmployeeDao.DeleteEmployee(employee);
            }
        }

        public IList<Employee> GetAllEmployees()
        {
            return EmployeeDao.GetAllEmployees();
        }

        public Employee GetEmployeeById(string id)
        {
            return EmployeeDao.GetEmployeeById(id);
        }

    }

}
