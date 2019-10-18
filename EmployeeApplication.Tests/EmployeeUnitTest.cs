using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Http.Results;

using System.Linq;
using EmployeeApplication.API.Controllers;
using EmployeeApplication.Models;

namespace EmployeeApplication.Tests
{
    [TestClass]
    public class EmployeeUnitTest
    {
        MockEmployeeRepository repository;
        EmployeeAPIController contactsApi;

        [TestInitialize]
        public void InitializeForTests()
        {
            repository = new MockEmployeeRepository();
            contactsApi = new EmployeeAPIController(repository);
        }

        [TestMethod]
        public void TestGetAllEmployee()
        {
            var contacts = contactsApi.Get() as OkNegotiatedContentResult<IEnumerable<Employee>>; ;
            Assert.AreEqual(contacts.Content.Count(), 6);
        }
    }
}
