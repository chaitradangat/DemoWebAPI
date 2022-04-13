﻿using DemoWebAPI.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWebAPI.DBService
{
    public class MongoDbService : IDBService
    {
        private readonly IMongoCollection<UserDetail> _userDetails;

        public MongoDbService(IUsersDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);

            var database = client.GetDatabase(settings.DatabaseName);

            _userDetails = database.GetCollection<UserDetail>(settings.UsersCollectionName);
        }


        public List<UserDetail> Get()
        {
            return _userDetails.Find(user => true).ToList();
        }

        public UserDetail Get(int id)
        {
            return _userDetails.Find(user => user.userid == id).FirstOrDefault();
        }

        public UserDetail Create(UserDetail userDetail)
        {
            _userDetails.InsertOne(userDetail);

            return userDetail;
        }

        public UserDetail Update(int id, UserDetail userDetail)
        {
            _userDetails.ReplaceOne(user => user.userid == id, userDetail);

            return userDetail;
        }

        public void Remove(int id)
        {
            _userDetails.DeleteOne(user => user.userid == id);
        }
    }
}
