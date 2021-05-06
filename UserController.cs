using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
        [HttpGet("{id}")]
        public async Task<User> GetUser(int id)
        {
            return await _userRepository.GetUser(id);
        }

        [HttpPost]
        public async Task<User> PostUser([FromBody] User user)
        {
            return await _userRepository.CreateUser(user);
        }

        [HttpPut("{id}")]
        public async Task<User> UpdateUser(int id, [FromBody] User user)
        {
            user.Id = id;
            return await _userRepository.UpdateUser(user);
        }

        [HttpDelete("{id}")]
        public async Task<User> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}