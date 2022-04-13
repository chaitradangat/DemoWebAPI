using DemoWebAPI.DBService;
using DemoWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWebAPI.UserService
{
    public class UserService : IUserService
    {
        private readonly IDBService _dBService;

        public UserService( IDBService dBService )
        {
            _dBService = dBService;
        }

        public List<UserDetail> Get()
        {
            return _dBService.Get();
        }

        public UserDetail Get(int id)
        {
            return _dBService.Get(id);
        }

    }
}
