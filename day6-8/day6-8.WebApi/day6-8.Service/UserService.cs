using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day6_8.Model.Common;
using day6_8.Service.Common;
using day6_8.Repository.Common;

namespace day6_8.Service
{
    public class UserService : IUserService
    {
        protected IUserRepository UserRepository { get; set; }

        public UserService(IUserRepository repo)
        {
            this.UserRepository = repo;
        }

        public async Task<IUser> GetUserAsync(Guid id)
        {
            return await UserRepository.PullDataAsync(id);
        }

        public async Task<List<IUser>> GetAllUserAsync()
        {
            return await UserRepository.PullAllDataAsync();
        }

        public async Task<string> InsertUserAsync(IUser data)
        {
            return await UserRepository.InsertDataAsync(data);
        }
        public async Task<string> UpdateUserAsync(Guid id, IUser data)
        {
            return await UserRepository.UpdateDataAsync(id, data);
        }
        public async Task<string> DeleteUserAsync(Guid id)
        {
            return await UserRepository.DeleteDataAsync(id);
        }
    }
}
