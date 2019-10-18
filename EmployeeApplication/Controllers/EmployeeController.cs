using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApplication.Controllers
{
    public class EmployeeController : Controller
    {
        //Hosted web api base URL
        const string BaseUri = "http://localhost:49575/api/";
        public ActionResult Employee()
        {

            IEnumerable<Employee> employee = Enumerable.Empty<Employee>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                //HTTP GET
                var responseTask = client.GetAsync("EmployeeApi/Get");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                    readTask.Wait();

                    employee = readTask.Result;
                    return View(employee);
                }
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(employee);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUri);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Employee>("EmployeeApi/Post", employee);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Employee");
                    }
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(employee);
        }
        public ActionResult Update(int employeeId)
        {
            Employee employee = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                //HTTP GET
                var responseTask = client.GetAsync("EmployeeApi/Get?id=" + employeeId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Employee>();
                    readTask.Wait();

                    employee = readTask.Result;
                }
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Employee>("EmployeeApi/Put", employee);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Employee");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(employee);
        }
        [ActionName("SearchEmployee")]
        public ActionResult Employee(SearchEmployee filter)
        {

            IEnumerable< Employee > employee = Enumerable.Empty<Employee>();
            ViewData["Employeefilter"] = filter;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                //HTTP GET
                var responseTask = client.GetAsync("EmployeeApi/Get");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                    readTask.Wait();

                    employee = readTask.Result;
                    if (filter.Name != null) {
                        employee= employee.Where(q => q.FName.ToLower().Contains(filter.Name.ToLower()) || q.LName.ToLower().Contains(filter.Name.ToLower()));
                    }
                    if (filter.StartDate != null && filter.EndDate !=null)
                    {
                        employee = employee.Where(q => q.DOJ >= filter.StartDate && q.DOJ <= filter.EndDate);
                    }

                    return View("Employee", employee);
                }
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View("Employee", employee);
        }
    }
}