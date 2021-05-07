using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day5.Model.Common;

namespace day5.Service.Common
{
    public interface IAccountService
    {
        Task<IAccount> GetAccountAsync(Guid id);
        Task<List<IAccount>> GetAllAccountAsync();
        Task<string> InsertAccountAsync(IAccount data);
        Task<string> UpdateAccountAsync(Guid id, IAccount data);
        Task<string> DeleteAccountAsync(Guid id);
    }
}
