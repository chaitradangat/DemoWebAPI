using DemoWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWebAPI.DBService
{
    public interface IDBService
    {
        public List<UserDetail> Get();

        public UserDetail Get(int id);
    }
}
