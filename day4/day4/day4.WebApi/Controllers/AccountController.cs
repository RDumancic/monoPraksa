using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using day4.Service;
using day4.Model;

namespace day4.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAccData(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, AccountService.GetAcc(id));
        }

        [HttpGet]
        public HttpResponseMessage GetAllData()
        {
            return Request.CreateResponse(HttpStatusCode.OK, AccountService.GetAllAcc());
        }

        [HttpPost]
        public HttpResponseMessage PostAccount([FromBody] Account data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, AccountService.InsertAcc(data));
        }

        [HttpPost]
        public HttpResponseMessage UpdateAccount(int id, [FromBody] Account data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, AccountService.UpdateAcc(id, data));
        }

        [HttpDelete]
        public HttpResponseMessage DeleteAccount(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, AccountService.DeleteAcc(id));
        }
    }
}
