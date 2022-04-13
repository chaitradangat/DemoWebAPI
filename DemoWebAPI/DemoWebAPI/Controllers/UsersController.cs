using DemoWebAPI.Domain;
using DemoWebAPI.UserService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserDetail>> Get()
        {
            return _userService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<UserDetail> Get(int id)
        {
            return _userService.Get(id);
        }

        [HttpPost]
        public ActionResult<UserDetail> Create(UserDetail userDetail)
        {
            return _userService.Create(userDetail);
        }

        [HttpPut("{id}")]
        public ActionResult<UserDetail> Update(int id, UserDetail userDetail)
        {
            return _userService.Update(id, userDetail);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _userService.Remove(id);

            return NoContent();
        }
    }
}
