namespace EmployeeApplication.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeApplication.Models.EmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EmployeeApplication.Models.EmployeeDbContext context)
        {
            List<Employee> employeeList = new List<Employee>() {
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
            foreach (Employee emp in employeeList)
            {
                context.Employees.AddOrUpdate(emp);
            }

            base.Seed(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
