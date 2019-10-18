using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeApplication.Models;
using System.Data.Entity;

namespace EmployeeApplication.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext employeeContext)
        {
            this._context = employeeContext;
        }
        public void AddEmployee(Employee employeeEntity)
        {
            _context.Employees.Add(employeeEntity);
        }

        public void DeleteEmployee(int employeeId)
        {
            Employee employee = _context.Employees.Find(employeeId);
            _context.Employees.Remove(employee);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employees.Find(employeeId);
        }

        public void UpdateEmployee(Employee employeeEntity)
        {
            _context.Entry(employeeEntity).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}