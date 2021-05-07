using System;
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
    public class AccountController : ApiController
    {
        protected IAccountService AccountService = new AccountService();

        [HttpGet]
        public async Task<HttpResponseMessage> GetAccData(Guid id)
        {
            IAccount account = await AccountService.GetAccountAsync(id);
            if(account == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Account doesn't exist");
            }
            return Request.CreateResponse(HttpStatusCode.OK, account);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllData()
        {
            List<IAccount> accounts = await AccountService.GetAllAccountAsync();
            if(accounts.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Entries");
            }
            return Request.CreateResponse(HttpStatusCode.OK, accounts);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostAccount([FromBody] Account data)
        {
            string response = await AccountService.InsertAccountAsync(data);
            if(response == "invalid")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Wrong Input");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Insert Successful");
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateAccount(Guid id, [FromBody] Account data)
        {
            string response = await AccountService.UpdateAccountAsync(id, data);
            if (response == "invalid")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Wrong Input");
            } else if (response == "nan")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Account doesn't exist");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Update Successful");
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteAccount(Guid id)
        {
            string response = await AccountService.DeleteAccountAsync(id);
            if (response == "nan")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Account Doesn't Exist");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Successful");
        }
    }
}
