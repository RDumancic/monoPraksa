using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using day6_8.Model.Common;
using day6_8.Service.Common;
using day6_8.Repository.Common;
using day6_8.Common;

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
            return await UserRepository.PullDataByIDAsync(id);
        }

        public async Task<List<IUser>> FindUserAsync(IUserFilter filterParams, ISorter sortParams, IDataPaging pageParams)
        {
            return await UserRepository.FindDataAsync(filterParams,sortParams,pageParams);
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
