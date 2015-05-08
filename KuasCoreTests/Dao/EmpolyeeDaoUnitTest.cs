using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KuasCoreTests.Dao
{

    [TestClass]
    public class EmployeeDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {
        #region 單元測試 Spring 必寫的內容 
        
        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    // assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public IEmployeeDao EmployeeDao { get; set; }


        [TestMethod]
        public void TestEmployeeDao_AddEmployee()
        {
            Employee employee = new Employee();
            employee.Id = "UnitTests";
            employee.Name = "單元測試";
            employee.Age = 15;
            EmployeeDao.AddEmployee(employee);

            Employee dbEmployee = EmployeeDao.GetEmployeeById(employee.Id);
            Assert.IsNotNull(dbEmployee);
            Assert.AreEqual(employee.Id, dbEmployee.Id);

            Console.WriteLine("員工編號為 = " + dbEmployee.Id);
            Console.WriteLine("員工姓名為 = " + dbEmployee.Name);
            Console.WriteLine("員工年齡為 = " + dbEmployee.Age);

            EmployeeDao.DeleteEmployee(dbEmployee);
            dbEmployee = EmployeeDao.GetEmployeeById(employee.Id);
            Assert.IsNull(dbEmployee);
        }

        [TestMethod]
        public void TestEmployeeDao_UpdateEmployee()
        {
            // 取得資料
            Employee employee = EmployeeDao.GetEmployeeById("dennis_yen");
            Assert.IsNotNull(employee);
            
            // 更新資料
            employee.Name = "單元測試";
            EmployeeDao.UpdateEmployee(employee);

            // 再次取得資料
            Employee dbEmployee = EmployeeDao.GetEmployeeById(employee.Id);
            Assert.IsNotNull(dbEmployee);
            Assert.AreEqual(employee.Name, dbEmployee.Name);
            
            Console.WriteLine("員工編號為 = " + dbEmployee.Id);
            Console.WriteLine("員工姓名為 = " + dbEmployee.Name);
            Console.WriteLine("員工年齡為 = " + dbEmployee.Age);

            Console.WriteLine("================================");

            // 將資料改回來
            employee.Name = "嚴志和";
            EmployeeDao.UpdateEmployee(employee);

            // 再次取得資料
            dbEmployee = EmployeeDao.GetEmployeeById(employee.Id);
            Assert.IsNotNull(dbEmployee);
            Assert.AreEqual(employee.Name, dbEmployee.Name);

            Console.WriteLine("員工編號為 = " + dbEmployee.Id);
            Console.WriteLine("員工姓名為 = " + dbEmployee.Name);
            Console.WriteLine("員工年齡為 = " + dbEmployee.Age);
        }


        [TestMethod]
        public void TestEmployeeDao_DeleteEmployee()
        {
            Employee newEmployee = new Employee();
            newEmployee.Id = "UnitTests";
            newEmployee.Name = "單元測試";
            newEmployee.Age = 15;
            EmployeeDao.AddEmployee(newEmployee);

            Employee dbEmployee = EmployeeDao.GetEmployeeById(newEmployee.Id);
            Assert.IsNotNull(dbEmployee);

            EmployeeDao.DeleteEmployee(dbEmployee);
            dbEmployee = EmployeeDao.GetEmployeeById(newEmployee.Id);
            Assert.IsNull(dbEmployee);
        }

        [TestMethod]
        public void TestEmployeeDao_GetEmployeeById()
        {
            Employee employee = EmployeeDao.GetEmployeeById("dennis_yen");
            Assert.IsNotNull(employee);
            Console.WriteLine("員工編號為 = " + employee.Id);
            Console.WriteLine("員工姓名為 = " + employee.Name);
            Console.WriteLine("員工年齡為 = " + employee.Age);
        }

    }
}
