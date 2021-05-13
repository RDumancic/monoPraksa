using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day6_8.Model.Common;
using day6_8.Common;

namespace day6_8.Repository.Common
{
    public interface IAccountRepository
    {
        Task<IAccount> PullDataByIDAsync(Guid id);
        Task<List<IAccount>> FindDataAsync(AccountFilter filterParams, AccountSorter sortParams, DataPaging pageParams);
        Task<string> InsertDataAsync(IAccount data);
        Task<string> UpdateDataAsync(Guid id, IAccount data);
        Task<string> DeleteDataAsync(Guid id);
    }
}
