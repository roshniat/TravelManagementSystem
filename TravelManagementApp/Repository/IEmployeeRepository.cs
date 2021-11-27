using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementApp.Models;

namespace TravelManagementApp.Repository
{
    public interface IEmployeeRepository
    {

        //Add an employee
        Task<int> AddEmployee(EmployeeRegistration employee);

        //get all employees
        Task<List<EmployeeRegistration>> GetEmployees();

        //get all projects
        Task<List<ProjectTable>> GetProjects();




    }
}
