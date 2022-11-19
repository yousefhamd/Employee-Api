using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Task3.Models;

namespace Task3.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values/GetEmployees
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return EmployeeMethods.GetEmployees();
        }

        // GET api/values/GetSumOfSalaries
        [HttpGet]
        public int GetSumOfSalaries()
        {
            return EmployeeMethods.GetSumOfSalaries();
        }

        // GET api/values/GetEmployee/5
        [HttpGet]
        public Employee GetEmployee(int id)
        {
            return EmployeeMethods.GetEmployee(id);
        }

        // POST api/values/InsertEmployee
        [HttpPost]
        public void InsertEmployee([FromBody]Employee employee)
        {
            EmployeeMethods.InsertEmployee(employee);
        }

        // POST api/values/InsertEmployeeNameStatus?Name=Ahmed&IsMarried=true
        [HttpPost]
        public void InsertEmployeeNameStatus([FromUri]string name, [FromUri]bool is_married)
        {
            EmployeeMethods.InsertEmployeeNameStatus(name, is_married);
        }

        // POST api/values/InsertEmployeeName?Name=Ahmed
        [HttpPost]
        public void InsertEmployeeName([FromUri]string name)
        {
            EmployeeMethods.InsertEmployeeName(name);
        }

        // PUT api/values/UpdateEmployeeData/5
        [HttpPut]
        public void UpdateEmployeeData(int id, [FromBody]Employee employee)
        {
            EmployeeMethods.UpdateEmployeeData(id, employee);
        }

        // PUT api/values/UpdateEmployeeSalary/5?Salary=5000
        [HttpPut]
        public void UpdateEmployeeSalary(int id, [FromUri]int salary)
        {
            EmployeeMethods.UpdateEmployeeSalary(id, salary);
        }

        // PUT api/values/UpdateMarriedSalaries
        [HttpPut]
        public void UpdateMarriedSalaries()
        {
            EmployeeMethods.UpdateMarriedSalaries();
        }

        // DELETE api/values/DeleteNullSalaries
        [HttpDelete]
        public void DeleteNullSalaries()
        {
            EmployeeMethods.DeleteNullSalaries();
        }

        // DELETE api/values/DeleteEmployeeData/5
        [HttpDelete]
        public void DeleteEmployeeData(int id)
        {
            EmployeeMethods.DeleteEmployeeData(id);
        }

        // DELETE api/values/DeleteAllEmployees
        [HttpDelete]
        public void DeleteAllEmployees()
        {
            EmployeeMethods.DeleteAllEmployees();
        }
    }
}
