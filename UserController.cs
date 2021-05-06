using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Stitch_BackEnd
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        [HttpPost]
        public User PostUser([FromBody] User user)
        {
            return _userRepository.CreateUser(user);
        }

        [HttpPut("{id}")]
        public User UpdateUser(int id, [FromBody] User user)
        {
            user.Id = id;
            return _userRepository.UpdateUser(user);
        }

        [HttpDelete("{id}")]
        public string DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }
    }
}