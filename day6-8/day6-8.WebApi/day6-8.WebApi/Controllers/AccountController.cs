using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using day6_8.Model.Common;
using day6_8.Service.Common;
using day6_8.Common;
using AutoMapper;

namespace day6_8.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        protected IAccountService AccountService { get; set; }
        private readonly IMapper mapper;

        public AccountController(IAccountService service, IMapper mapper)
        {
            this.AccountService = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAccData(Guid id)
        {
            IAccount account = await AccountService.GetAccountAsync(id);
            if (account == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Account doesn't exist");
            }
            return Request.CreateResponse(HttpStatusCode.OK, mapper.Map<AccountRest>(account));
        }

        [HttpGet]
        public async Task<HttpResponseMessage> FindData([FromUri] AccountFilter filterParams, [FromUri] AccountSorter sortParams,[FromUri]DataPaging pageParams)
        {
            List<IAccount> accounts = await AccountService.FindAccountAsync(filterParams,sortParams,pageParams);
            if (accounts.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Entries");
            }
            return Request.CreateResponse(HttpStatusCode.OK, mapper.Map<List<AccountRest>>(accounts));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostAccount([FromBody] AccountRest data)
        {
            string response = await AccountService.InsertAccountAsync(mapper.Map<IAccount>(data));
            if (response == "invalid")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Wrong Input");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Insert Successful");
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateAccount(Guid id, [FromBody] AccountRest data)
        {
            string response = await AccountService.UpdateAccountAsync(id, mapper.Map<IAccount>(data));
            if (response == "invalid")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Wrong Input");
            }
            else if (response == "nan")
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

    public class AccountRest
    {
        public string Details { get; set; }
        public string Status { get; set; }
    }
}
