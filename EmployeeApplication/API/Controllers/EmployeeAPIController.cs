using EmployeeApplication.Models;
using EmployeeApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeApplication.API.Controllers
{
    public class EmployeeAPIController : ApiController
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeAPIController(IEmployeeRepository employeeContext)
        {
            this._employeeRepository = employeeContext;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var employeeInfolist = _employeeRepository.GetAllEmployee();
            if (employeeInfolist.Count() == 0)
            {
                return NotFound();
            }
            return Ok(employeeInfolist);
        }
        // GET: api/Employee/5
        public IHttpActionResult Get(int id)
        {
            var employeeInfo = _employeeRepository.GetEmployeeById(id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            return Ok(employeeInfo);
        }

        // POST: api/Employee
        public IHttpActionResult Post([FromBody]Employee value)
        {

            try
            {
                _employeeRepository.AddEmployee(value);
                _employeeRepository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // PUT: api/Employee/5
        public IHttpActionResult Put([FromBody]Employee value)
        {
            try
            {
                _employeeRepository.UpdateEmployee(value);
                _employeeRepository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
