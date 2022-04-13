using DemoWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWebAPI.UserService
{
    public interface IUserService
    {
        public List<UserDetail> Get();

        public UserDetail Get(int id);
    }
}
