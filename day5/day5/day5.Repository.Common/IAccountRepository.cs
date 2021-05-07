using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day5.Model.Common;

namespace day5.Repository.Common
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
