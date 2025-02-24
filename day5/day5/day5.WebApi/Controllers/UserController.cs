﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using day5.Model.Common;
using day5.Model;
using day5.Service.Common;
using day5.Service;

namespace day5.WebApi.Controllers
{
    public class UserController : ApiController
    {
        protected IUserService UserService = new UserService();

        [HttpGet]
        public async Task<HttpResponseMessage> GetAccData(Guid id)
        {
            IUser user = await UserService.GetUserAsync(id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "User doesn't exist");
            }
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllData()
        {
            List<IUser> users = await UserService.GetAllUserAsync();
            if (users.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Entries");
            }
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostUser([FromBody] User data)
        {
            string response = await UserService.InsertUserAsync(data);
            if (response == "invalid")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Wrong Input");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Insert Successful");
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateUser(Guid id, [FromBody] User data)
        {
            string response = await UserService.UpdateUserAsync(id, data);
            if (response == "invalid")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Wrong Input");
            }
            else if (response == "nan")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "User doesn't exist");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Update Successful");
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteUser(Guid id)
        {
            string response = await UserService.DeleteUserAsync(id);
            if (response == "nan")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "User Doesn't Exist");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Successful");
        }
    }
}
