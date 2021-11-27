using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementApp.Models;

namespace TravelManagementApp.Repository
{
    public interface ILoginRepository
    {
        //get all users with login
        public Login GetUser(Login login);

        Task<ActionResult<Login>> GetUserByPassword(string un, string psw);



    }
}
