using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day6_8.Model.Common;

namespace day6_8.Service.Common
{
    public interface IUserService
    {
        Task<IUser> GetUserAsync(Guid id);
        Task<List<IUser>> GetAllUserAsync();
        Task<string> InsertUserAsync(IUser data);
        Task<string> UpdateUserAsync(Guid id, IUser data);
        Task<string> DeleteUserAsync(Guid id);
    }
}