using System;
using System.Collections.Generic;
using AutoMapper;
using day6_8.Model.Common;
using day6_8.Repository;
using day6_8.WebApi.Controllers;

namespace day6_8.WebApi.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AccountRest, IAccount>();
            CreateMap<IAccount, AccountRest>();
            CreateMap<UserRest, IUser>();
            CreateMap<IUser, UserRest>();
            CreateMap<IAccount, AccountEntity>();
            CreateMap<AccountEntity, IAccount>();
            CreateMap<IUser, UserEntity>();
            CreateMap<UserEntity, IUser>();
        }
    }
}