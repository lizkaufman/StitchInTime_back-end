using System;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stitch_BackEnd
{
    public class UserRepository : BaseRepository
    {
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<User>("SELECT * FROM Users;");
        }

        public async Task<User> GetUser(long id)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleAsync<User>("SELECT * FROM Users WHERE id = @id", new { id = id });
        }
        public async Task<User> CreateUser(User user)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleAsync<User>("INSERT INTO Users (firstName, lastName, email, projects) VALUES (@FirstName, @LastName, @Email, @Projects) RETURNING *;", user);
        }
        public async Task<User> UpdateUser(User user)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleAsync<User>("UPDATE Users SET firstName = @FirstName, lastName = @LastName, email = @Email, projects = @Projects WHERE id = @id RETURNING *;", user);
        }
        public async Task<User> DeleteUser(long id)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleAsync<User>("DELETE FROM Users WHERE id = @id RETURNING *", new { id = id });
        }
    }
}
