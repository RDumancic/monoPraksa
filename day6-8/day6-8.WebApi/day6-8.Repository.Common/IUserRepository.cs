using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day6_8.Model.Common;
using day6_8.Common;

namespace day6_8.Repository.Common
{
    public interface IUserRepository
    {
        Task<IUser> PullDataByIDAsync(Guid id);
        Task<List<IUser>> FindDataAsync(IUserFilter filterParams, ISorter sortParams, IDataPaging pageParams);
        Task<string> InsertDataAsync(IUser data);
        Task<string> UpdateDataAsync(Guid id, IUser data);
        Task<string> DeleteDataAsync(Guid id);
    }
}