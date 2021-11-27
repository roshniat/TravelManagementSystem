using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelManagementApp.Models;

namespace TravelManagementApp.Repository
{
    public interface IRequestRepository
    {

        //get all requests
        Task<List<RequestTable>> GetRequests();

        //add a request
        Task<int> AddRequest(RequestTable request);

        //update a request
        Task UpdateRequest(RequestTable request);



    }
}
