using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day5.Model.Common;

namespace day5.Repository.Common
{
    public interface IUserRepository
    {
        Task<IUser> PullDataAsync(Guid id);
        Task<List<IUser>> PullAllDataAsync();
        Task<string> InsertDataAsync(IUser data);
        Task<string> UpdateDataAsync(Guid id, IUser data);
        Task<string> DeleteDataAsync(Guid id);
    }
}
