using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day6_8.Model.Common;
using day6_8.Common;

namespace day6_8.Service.Common
{
    public interface IAccountService
    {
        Task<IAccount> GetAccountAsync(Guid id);
        Task<List<IAccount>> FindAccountAsync(IAccountFilter filterParams, ISorter sortParams, IDataPaging pageParams);
        Task<string> InsertAccountAsync(IAccount data);
        Task<string> UpdateAccountAsync(Guid id, IAccount data);
        Task<string> DeleteAccountAsync(Guid id);
    }
}
