using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day6_8.Model.Common;

namespace day6_8.Repository.Common
{
    public interface IAccountRepository
    {
        Task<IAccount> PullDataAsync(Guid id);
        Task<List<IAccount>> PullAllDataAsync();
        Task<string> InsertDataAsync(IAccount data);
        Task<string> UpdateDataAsync(Guid id, IAccount data);
        Task<string> DeleteDataAsync(Guid id);
    }
}
