using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementApp.Models;

namespace TravelManagementApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //database
        TravelManagementDBContext db;

        //Constructor dependency injection
        public EmployeeRepository(TravelManagementDBContext _db)
        {
            this.db = _db;
        }

        //Add an employee
        #region Add an employee

        public async Task<int> AddEmployee(EmployeeRegistration employee)
        {
            if (db != null)
            {
                await db.EmployeeRegistration.AddAsync(employee);
                await db.SaveChangesAsync(); //commit the transaction
                return employee.EmpId;

            }
            return 0;

        }

        #endregion

        //get all employees



        #region Get employees

        public async Task<List<EmployeeRegistration>> GetEmployees()
        {
            if (db != null)
            {
                return await db.EmployeeRegistration.ToListAsync();
            }
            return null;

        }
        #endregion

        //get all projects


        #region Get projects 

        public async Task<List<ProjectTable>> GetProjects()
        {
            if (db != null)
            {
                return await db.ProjectTable.ToListAsync();
            }
            return null;

        }
        #endregion


    }
}
