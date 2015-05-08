using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;

namespace KuasCoreTests.Services
{
    [TestClass]
    public class EmployeeServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public IEmployeeService EmployeeService { get; set; }

        [TestMethod]
        public void TestEmployeeService_AddEmployee()
        {
            Employee empolyee = new Employee();
            empolyee.Id = "UnitTests";
            empolyee.Name = "單元測試";
            empolyee.Age = 15;
            EmployeeService.AddEmployee(empolyee);

            Employee dbEmpolyee = EmployeeService.GetEmployeeById(empolyee.Id);
            Assert.IsNotNull(dbEmpolyee);
            Assert.AreEqual(empolyee.Id, dbEmpolyee.Id);

            Console.WriteLine("員工編號為 = " + dbEmpolyee.Id);
            Console.WriteLine("員工姓名為 = " + dbEmpolyee.Name);
            Console.WriteLine("員工年齡為 = " + dbEmpolyee.Age);

            EmployeeService.DeleteEmployee(dbEmpolyee);
            dbEmpolyee = EmployeeService.GetEmployeeById(empolyee.Id);
            Assert.IsNull(dbEmpolyee);
        }

        [TestMethod]
        public void TestEmployeeService_UpdateEmployee()
        {
            // 取得資料
            Employee empolyee = EmployeeService.GetEmployeeById("dennis_yen");
            Assert.IsNotNull(empolyee);

            // 更新資料
            empolyee.Name = "單元測試";
            EmployeeService.UpdateEmployee(empolyee);

            // 再次取得資料
            Employee dbEmpolyee = EmployeeService.GetEmployeeById(empolyee.Id);
            Assert.IsNotNull(dbEmpolyee);
            Assert.AreEqual(empolyee.Name, dbEmpolyee.Name);

            Console.WriteLine("員工編號為 = " + dbEmpolyee.Id);
            Console.WriteLine("員工姓名為 = " + dbEmpolyee.Name);
            Console.WriteLine("員工年齡為 = " + dbEmpolyee.Age);

            Console.WriteLine("================================");

            // 將資料改回來
            empolyee.Name = "嚴志和";
            EmployeeService.UpdateEmployee(empolyee);

            // 再次取得資料
            dbEmpolyee = EmployeeService.GetEmployeeById(empolyee.Id);
            Assert.IsNotNull(dbEmpolyee);
            Assert.AreEqual(empolyee.Name, dbEmpolyee.Name);

            Console.WriteLine("員工編號為 = " + dbEmpolyee.Id);
            Console.WriteLine("員工姓名為 = " + dbEmpolyee.Name);
            Console.WriteLine("員工年齡為 = " + dbEmpolyee.Age);
        }


        [TestMethod]
        public void TestEmployeeService_DeleteEmployee()
        {
            Employee newEmpolyee = new Employee();
            newEmpolyee.Id = "UnitTests";
            newEmpolyee.Name = "單元測試";
            newEmpolyee.Age = 15;
            EmployeeService.AddEmployee(newEmpolyee);

            Employee dbEmpolyee = EmployeeService.GetEmployeeById(newEmpolyee.Id);
            Assert.IsNotNull(dbEmpolyee);

            EmployeeService.DeleteEmployee(dbEmpolyee);
            dbEmpolyee = EmployeeService.GetEmployeeById(newEmpolyee.Id);
            Assert.IsNull(dbEmpolyee);
        }

        [TestMethod]
        public void TestEmployeeService_GetEmployeeById()
        {
            Employee empolyee = EmployeeService.GetEmployeeById("dennis_yen");
            Assert.IsNotNull(empolyee);

            Console.WriteLine("員工編號為 = " + empolyee.Id);
            Console.WriteLine("員工姓名為 = " + empolyee.Name);
            Console.WriteLine("員工年齡為 = " + empolyee.Age);
        }

    }
}
