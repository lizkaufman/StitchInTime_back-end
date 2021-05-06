using System;
using Dapper;
using System.Collections.Generic;

namespace Stitch_BackEnd
{
    public class UserRepository : BaseRepository
    {
        public IEnumerable<User> GetAllUsers()
        {
            using var connection = CreateConnection();
            return connection.Query<User>("SELECT * FROM Users;");
        }

        public User GetUser(long id)
        {
            using var connection = CreateConnection();
            return connection.QuerySingle<User>("SELECT * FROM Users WHERE id = @id", new { id = id });
        }
        public User CreateUser(User user)
        {
            using var connection = CreateConnection();
            return connection.QuerySingle<User>("INSERT INTO Users (firstName, lastName, email, projects) VALUES (@FirstName, @LastName, @Email, @Projects) RETURNING *;", user);
        }
        public User UpdateUser(User user)
        {
            using var connection = CreateConnection();
            return connection.QuerySingle<User>("UPDATE Users SET firstName = @FirstName, lastName = @LastName, email = @Email, projects = @Projects WHERE id = @id RETURNING *;", user);
        }
        public string DeleteUser(long id)
        {
            using var connection = CreateConnection();
            connection.Execute("DELETE FROM Users WHERE id = @id", new { id = id });
            return $"User {id} has been deleted.";
        }
    }
}
