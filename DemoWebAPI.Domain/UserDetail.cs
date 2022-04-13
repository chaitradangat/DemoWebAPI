using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWebAPI.Domain
{
    public class UserDetail
    {
        
        //[BsonElement("id")]
        
        public int userid { get; set; }

        //[BsonElement("name")]
        public string name { get; set; }

        //[BsonElement("username")]
        public string username { get; set; }

        //[BsonElement("email")]
        public string email { get; set; }

        //[BsonElement("address")]
        public Address address { get; set; }

        //[BsonElement("phone")]
        public string phone { get; set; }

        //[BsonElement("website")]
        public string website { get; set; }

        //[BsonElement("company")]
        public Company company { get; set; }
    }
}
