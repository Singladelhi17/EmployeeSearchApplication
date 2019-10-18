using EmployeeApplication.Models;
using EmployeeApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Tests
{
    class MockEmployeeRepository : IEmployeeRepository
    {
        List<Employee> employeeList;
        public bool FailGet { get; set; }
        public MockEmployeeRepository()
        {

            employeeList = new List<Employee>() {
             new Employee()
                {
                        FName = "Mark",
                        LName = "Hastings",
                        Gender = "Male",
                        Age = 30,
                        JobTitle = "Developer",
                        DOJ = new DateTime(2017, 1, 18),
                        DepartmentName="IT"
                },
                new Employee()
                {
                        FName = "Ben",
                        LName = "Hoskins",
                        Gender = "Male",
                        Age = 35,
                        JobTitle = "Sr. Developer",
                        DOJ= new DateTime(2018,1,22),
                        DepartmentName="HR"
                },
                new Employee()
                {
                        FName = "John",
                        LName = "Stanmore",
                        Gender = "Male",
                        Age = 45,
                        JobTitle = "Project Manager",
                        DOJ=new DateTime(2016,12,22),
                        DepartmentName ="Payroll"


                },
                new Employee()
                {
                        FName = "Mary",
                        LName = "Lambeth",
                        Gender = "Female",
                        Age = 60,
                        JobTitle = "Sr. Recruiter",
                        DOJ=new DateTime(2017,7,28),
                        DepartmentName ="Payroll"

                },
                new Employee()
                {
                       FName = "Steve",
                        LName = "Pound",
                        Gender = "Male",
                        Age = 38,
                        JobTitle = "Sr. Payroll Admin",
                        DOJ=new DateTime(2017,5,22),
                        DepartmentName="HR"

                },
                new Employee()
                {
                        FName = "Valarie",
                        LName = "Vikings",
                        Gender = "Female",
                        Age = 45,
                       JobTitle = "Payroll Admin",
                       DOJ=new DateTime(2015,10,08),
                       DepartmentName="IT"

                }

            };
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return employeeList;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var employee = employeeList.FirstOrDefault(q => q.EmployeeID == employeeId);
            return employee;
        }

        public void AddEmployee(Employee employeeEntity)
        {
            employeeList.Add(employeeEntity);
        }

        public void UpdateEmployee(Employee employeeEntity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
