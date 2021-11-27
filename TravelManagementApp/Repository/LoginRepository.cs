using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementApp.Models;

namespace TravelManagementApp.Repository
{
    public class LoginRepository : ILoginRepository
    {
        //database
        TravelManagementDBContext db;

        //Constructor dependency injection
        public LoginRepository(TravelManagementDBContext _db)
        {
            this.db = _db;
        }

        #region Get User

        public Login GetUser(Login login)
        {
            if (db != null)
            {
                Login dbUser = db.Login.FirstOrDefault(em => em.UserName == login.UserName && em.Password == login.Password);
                if (dbUser != null)
                {
                    return dbUser;
                }
            }
            return null;
        }

        #endregion
        #region get user by password

        public async Task<ActionResult<Login>> GetUserByPassword(string un, string psw)
        {
            if (db != null)
            {
                Login dbUser = await db.Login.FirstOrDefaultAsync(em => em.UserName == un && em.Password == psw);


                return dbUser;

            }
            return null;
        }

        #endregion


    }
}
