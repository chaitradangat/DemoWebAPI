using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWebAPI.DBService
{
    public class UsersDatabaseSettings : IUsersDatabaseSettings
    {
        public string UsersCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
