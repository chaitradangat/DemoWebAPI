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

        public UserDetail Create(UserDetail userDetail);

        public UserDetail Update(int id, UserDetail userDetail);

        public void Remove(int id);
    }
}
