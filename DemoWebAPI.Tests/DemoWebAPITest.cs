using DemoWebAPI.Controllers;
using DemoWebAPI.DBService;
using DemoWebAPI.Domain;
using DemoWebAPI.UserService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace DemoWebAPI.Tests
{
    public class DemoWebAPITest
    {
        private readonly UsersController _controller;

        private readonly IUserService _userService;

        private readonly IDBService _dBService;

        private readonly IUsersDatabaseSettings settings;

        public DemoWebAPITest()
        {
            settings = new UsersDatabaseSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "UsersDB",
                UsersCollectionName = "UserDetails"
            };

            _dBService = new MongoDbService(settings);

            _userService = new UserService.UserService(_dBService);

            _controller = new UsersController(_userService);
        }


        [Fact]
        public void Get_Should_Return_UserDetails_When_Called()
        {
            //act
            var result = _controller.Get();

            //assert
            Assert.IsType<List<UserDetail>>(result.Value);
        }

        [Fact]
        public void GetByID_Should_Return_User_With_ID_When_Called()
        {
            //act
            var result = _controller.Get(1);

            //assert
            Assert.Equal(1, result.Value.userid);
        }

        [Fact]
        public void Create_Should_Return_User_Created_When_UserIsPassed()
        {
            //arrange
            var newUser = new UserDetail
            {
                userid = 99,
                email = "unittest@email.com",
                name = "testfirstname testlastname",
                username = "testuser99",
                phone = "18001234",
                website = "demo.com",
                address = new Address { city = "testcity", street = "teststreet", suite = "testsuite", zipcode = "4000067", geo = new Geo { lat = "12.33", lng = "15.33" } },
                company = new Company { name = "testcompany", catchPhrase = "we are a test company", bs = "testabc" }
            };

            //act
            var createdUser = _controller.Create(newUser);

            _controller.Remove(createdUser.Value.userid);

            //assert
            Assert.Equal<UserDetail>(newUser, createdUser.Value);
        }

        [Fact]
        public void Update_Should_Replace_User_When_Called()
        {
            //arrange
            var changedUser =  new UserDetail
            {
                userid = 99,
                email = "newunittest@email.com",
                name = "testfirstname testlastname",
                username = "testuser99",
                phone = "18001234",
                website = "demo.com",
                address = new Address { city = "testcity", street = "teststreet", suite = "testsuite", zipcode = "4000067", geo = new Geo { lat = "12.33", lng = "15.33" } },
                company = new Company { name = "testcompany", catchPhrase = "we are a test company", bs = "testabc" }
            };

            //act
            var updatedUser = _controller.Update(changedUser.userid,changedUser);

            //assert
            Assert.Equal<UserDetail>(changedUser, updatedUser.Value);
        }

        [Fact]
        public void Delete_Should_Remove_User_When_Called()
        {
            //arrange
            var newUser = new UserDetail
            {
                userid = 999,
                email = "unittest@email.com",
                name = "testfirstname testlastname",
                username = "testuser99",
                phone = "18001234",
                website = "demo.com",
                address = new Address { city = "testcity", street = "teststreet", suite = "testsuite", zipcode = "4000067", geo = new Geo { lat = "12.33", lng = "15.33" } },
                company = new Company { name = "testcompany", catchPhrase = "we are a test company", bs = "testabc" }
            };

            //act
            var createdUser = _controller.Create(newUser).Value;

            _controller.Remove(999);

            var usersAfterDeletion = _controller.Get().Value;

            //assert
            Assert.DoesNotContain<UserDetail>(createdUser, usersAfterDeletion);
        }
    }
}
