using KuasCore.Dao;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services
{

    /// <summary>
    ///     員工資料維護的 Service.
    /// </summary>
    public interface IEmployeeService
    {

        /// <summary>
        ///     新增員工資料.
        /// </summary>
        /// <param name="employee">
        ///     員工資料.
        /// </param>
        void AddEmployee(Employee employee);

        /// <summary>
        ///     修改員工資料.
        /// </summary>
        /// <param name="employee">
        ///     員工資料.
        /// </param>
        void UpdateEmployee(Employee employee);

        /// <summary>
        ///     刪除員工資料.
        /// </summary>
        /// <param name="employee">
        ///     員工資料.
        /// </param>
        void DeleteEmployee(Employee employee);

        /// <summary>
        ///     取得所有員工資料.
        /// </summary>
        /// <returns>
        ///     所有員工資料.
        /// </returns>
        IList<Employee> GetAllEmployees();

        /// <summary>
        ///     依據 ID 取得員工資料.
        /// </summary>
        /// <param name="id">
        ///     員工 Id.
        /// </param>
        /// <returns>
        ///     該員工資料.
        /// </returns>
        Employee GetEmployeeById(string id);

    }
}
