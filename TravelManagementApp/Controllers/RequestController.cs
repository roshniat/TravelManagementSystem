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
    public class RequestController : ControllerBase
    {
        //constructor dependency injection
        IRequestRepository requestRepo;

        public RequestController(IRequestRepository _r)
        {
            this.requestRepo = _r;
        }

        //get all requests
        #region get all request
        [HttpGet]

        public async Task<IActionResult> GetRequests()
        {
            try
            {
                var requests = await requestRepo.GetRequests();
                if (requests == null)
                {
                    return NotFound();
                }
                return Ok(requests);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        //add a request
        #region Add a request

        [HttpPost]

        public async Task<IActionResult> AddRequest([FromBody] RequestTable request)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var requestId = await requestRepo.AddRequest(request);
                    if (requestId > 0)
                    {
                        return Ok(requestId);
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

        #region update a request
        [HttpPut]

        public async Task<IActionResult> UpdateRequest([FromBody] RequestTable request)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await requestRepo.UpdateRequest(request);
                    return Ok();



                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();

        }

        #endregion
    }
}
