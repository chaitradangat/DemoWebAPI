using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWebAPI.DBService
{
    public interface IUsersDatabaseSettings
    {
        public string UsersCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
