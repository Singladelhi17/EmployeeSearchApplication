using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeById(int employeeId);
        void AddEmployee(Employee employeeEntity);
        void UpdateEmployee(Employee employeeEntity);
        void DeleteEmployee(int employeeId);
        void Save();
    }
}