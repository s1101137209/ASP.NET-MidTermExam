using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System;
using System.Collections.Generic;

namespace KuasCore.Services.Impl
{
    public class TxEmployeeService : ITxEmployeeService
    {

        public IEmployeeDao EmployeeDao { get; set; }

        public void ExecuteTxMethod()
        {
            Employee employee1 = new Employee();
            employee1.Id = "AAA";
            employee1.Name = "AAA";
            employee1.Age = 0;
            EmployeeDao.AddEmployee(employee1);

            Employee employee2 = new Employee();
            employee2.Id = "BBB";
            employee2.Name = "BBB";
            employee2.Age = 0;
            EmployeeDao.AddEmployee(employee2);

            Employee dbEmployee = EmployeeDao.GetEmployeeById("AAA");
            dbEmployee.Name = "XXX";
            EmployeeDao.UpdateEmployee(dbEmployee);

            throw new Exception("Get an exception");
        }

    }

}
