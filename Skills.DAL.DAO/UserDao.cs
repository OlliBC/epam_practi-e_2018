using Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Skills.DAL.DAO
{
    public class UserDao : IUserDao
    {
        private readonly string _connectionString;

        public UserDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Skills"].ConnectionString;
        }

        public int AddUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddUser";

                var name = new SqlParameter("@NAME", System.Data.SqlDbType.VarChar)
                {
                    Value = user.Name
                };

                command.Parameters.Add(name);

                var password = new SqlParameter("@PASSWORD", System.Data.SqlDbType.VarChar)
                {
                    Value = user.Password
                };

                command.Parameters.Add(password);

                var role = new SqlParameter("@ROLE", System.Data.SqlDbType.Int)
                {
                    Value = user.Role
                };

                command.Parameters.Add(role);

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public int DeleteUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "DeleteUser";

                var userId = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(userId);

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }

        public User GetUserById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetUserById";

                var userId = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(userId);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new User
                    {
                        UserId = (int)reader["id_user"],
                        Name = (string)reader["Name"],
                        Role = (int)reader["Role"],
                    };
                }
            }

            return null;
        }

        public IEnumerable<User> GetUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetUsers";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User{
                        UserId = (int)reader["id_user"],
                        Name = (string)reader["Name"],
                        Role = (int)reader["Role"],
                    };
                }
            }
        }

        public int UpdateUserForAdmin(int id, int role)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "UpdateUserForAdmin";

                var userId = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                var userRole = new SqlParameter("@ROLE", System.Data.SqlDbType.Int)
                {
                    Value = role
                };

                command.Parameters.AddRange(new SqlParameter[] { userId, userRole });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();

            }
        }

        public int UpdateUserForUsers(int id, string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "UpdateUserForUsers";

                var userId = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                var userName = new SqlParameter("@NAME", System.Data.SqlDbType.VarChar)
                {
                    Value = name
                };

                command.Parameters.AddRange(new SqlParameter[] { userId, userName });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();

            }
        }
    }
}
