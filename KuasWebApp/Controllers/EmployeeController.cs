using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class EmployeeController : ApiController
    {

        public IEmployeeService EmployeeService { get; set; }

        [HttpPost]
        public Employee AddEmployee(Employee employee)
        {
            CheckEmployeeIsNotNullThrowException(employee);

            try
            {
                EmployeeService.AddEmployee(employee);
                return EmployeeService.GetEmployeeById(employee.Id);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public Employee UpdateEmployee(Employee employee)
        {
            CheckEmployeeIsNullThrowException(employee);

            try
            {
                EmployeeService.UpdateEmployee(employee);
                return EmployeeService.GetEmployeeById(employee.Id);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteEmployee(Employee employee)
        {
            try
            {
                EmployeeService.DeleteEmployee(employee);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Employee> GetAllEmployees()
        {
            return EmployeeService.GetAllEmployees();
        }

        [HttpGet]
        [ActionName("byId")]
        public Employee GetEmployeeById(string id)
        {
            var employee = EmployeeService.GetEmployeeById(id);

            if (employee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return employee;
        }

        /// <summary>
        ///     檢查員工資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="employee">
        ///     員工資料.
        /// </param>
        private void CheckEmployeeIsNullThrowException(Employee employee)
        {
            Employee dbEmployee = EmployeeService.GetEmployeeById(employee.Id);

            if (dbEmployee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查員工資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="employee">
        ///     員工資料.
        /// </param>
        private void CheckEmployeeIsNotNullThrowException(Employee employee)
        {
            Employee dbEmployee = EmployeeService.GetEmployeeById(employee.Id);

            if (dbEmployee != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

    }

}
