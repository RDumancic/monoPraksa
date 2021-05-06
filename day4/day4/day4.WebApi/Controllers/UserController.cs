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
    public class UserController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAccData(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.GetUser(id));
        }

        [HttpGet]
        public HttpResponseMessage GetAllData()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.GetAllUser());
        }

        [HttpPost]
        public HttpResponseMessage PostUser([FromBody] User data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.InsertUser(data));
        }

        [HttpPost]
        public HttpResponseMessage UpdateUser(int id, [FromBody] User data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.UpdateUser(id, data));
        }

        [HttpDelete]
        public HttpResponseMessage DeleteUser(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.DeleteUser(id));
        }
    }
}
