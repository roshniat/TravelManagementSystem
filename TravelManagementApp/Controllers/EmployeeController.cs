using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementApp.Models;
using TravelManagementApp.Repository;

namespace TravelManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //constructor dependency injection
        IEmployeeRepository employeeRepo;

        public EmployeeController(IEmployeeRepository _e)
        {
            this.employeeRepo = _e;
        }

        //add an employee 
        #region add employee details
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRegistration employee)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var empId = await employeeRepo.AddEmployee(employee);
                    if (empId > 0)
                    {
                        return Ok(empId);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();

        }

        #endregion

        #region Get all Employees

        [HttpGet]
       
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await employeeRepo.GetEmployees();
                if (employees == null)
                {
                    return NotFound();
                }
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        #region Get all Projects
        [Route("GetProjects")]
        [HttpGet]

        public async Task<IActionResult> GetProjects()
        {
            try
            {
                var projects = await employeeRepo.GetProjects();
                if (projects == null)
                {
                    return NotFound();
                }
                return Ok(projects);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion
    }
}
