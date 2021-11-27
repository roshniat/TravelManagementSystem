using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementApp.Models;

namespace TravelManagementApp.Repository
{
    public class RequestRepository : IRequestRepository
    {
        //database
        TravelManagementDBContext db;

        //Constructor dependency injection
        public RequestRepository(TravelManagementDBContext _db)
        {
            this.db = _db;
        }

        //CRUD operations
        //add a request
        #region Add Request

        public async Task<int> AddRequest(RequestTable request)
        {
            if (db != null)
            {
                await db.RequestTable.AddAsync(request);
                await db.SaveChangesAsync(); //commit the transaction
                return request.RequestId;

            }
            return 0;

        }

        #endregion

        //Get all requests
        #region Get all request

        public async Task<List<RequestTable>> GetRequests()
        {
            if (db != null)
            {
                return await db.RequestTable.ToListAsync();
            }
            return null;
        }

        #endregion

        //update a request
        #region Update a Request

        public async Task UpdateRequest(RequestTable request)
        {
            if (db != null)
            {
                db.RequestTable.Update(request);
                await db.SaveChangesAsync(); //commit the transaction


            }
        }

        #endregion




    }
}
