using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day5.Model.Common;

namespace day5.Service.Common
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
