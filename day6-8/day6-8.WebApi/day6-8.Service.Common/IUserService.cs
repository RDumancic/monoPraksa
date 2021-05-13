using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day6_8.Model.Common;
using day6_8.Common;

namespace day6_8.Service.Common
{
    public interface IUserService
    {
        Task<IUser> GetUserAsync(Guid id);
        Task<List<IUser>> FindUserAsync(UserFilter filterParams, UserSorter sortParams, DataPaging pageParams);
        Task<string> InsertUserAsync(IUser data);
        Task<string> UpdateUserAsync(Guid id, IUser data);
        Task<string> DeleteUserAsync(Guid id);
    }
}