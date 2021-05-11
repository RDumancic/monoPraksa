using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day6_8.Model.Common;
using day6_8.Service.Common;
using day6_8.Repository.Common;

namespace day6_8.Service
{
    public class AccountService : IAccountService
    {
        protected IAccountRepository AccountRepository { get; set; }

        public AccountService() { }

        public AccountService(IAccountRepository repo)
        {
            this.AccountRepository = repo;
        }

        public async Task<IAccount> GetAccountAsync(Guid id)
        {
            return await AccountRepository.PullDataAsync(id);
        }

        public async Task<List<IAccount>> GetAllAccountAsync()
        {
            return await AccountRepository.PullAllDataAsync();
        }

        public async Task<string> InsertAccountAsync(IAccount data)
        {
            return await AccountRepository.InsertDataAsync(data);
        }
        public async Task<string> UpdateAccountAsync(Guid id, IAccount data)
        {
            return await AccountRepository.UpdateDataAsync(id, data);
        }
        public async Task<string> DeleteAccountAsync(Guid id)
        {
            return await AccountRepository.DeleteDataAsync(id);
        }
    }
}
