using Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Skills.DAL.DAO
{
    public class SkillDao : ISkillDao
    {
        private readonly string _connectionString;

        public SkillDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Skills"].ConnectionString;
        }

        public void AddSkill(int id, Skill skill)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddSkill";

                var userId = new SqlParameter("@ID_USER", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                var name = new SqlParameter("@NAME", System.Data.SqlDbType.VarChar)
                {
                    Value = skill.SkillName
                };


                var comment = new SqlParameter("@COMMENT", System.Data.SqlDbType.VarChar)
                {
                    Value = skill.Comment
                };


                command.Parameters.AddRange(new SqlParameter[]{ userId, name, comment });

                connection.Open();

                command.ExecuteScalar();
            }
        }

        public int DeleteSkill(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "DeleteSkill";

                var userId = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(userId);

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();

            }
        }

        public Skill GetSkillById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetSkillById";

                var userId = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(userId);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new Skill
                    {
                        SkillId = (int)reader["id_skill"],
                        SkillName = (string)reader["Name"],
                        Comment = (string)reader["Comment"]
                    };
                }
            }

            return null;
        }

        public IEnumerable<Skill> GetSkills()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetSkills";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Skill
                    {
                        SkillId = (int)reader["id_skill"],
                        SkillName = (string)reader["Name"],
                        Comment = (string)reader["Comment"]
                    };
                }
            }
        }

        public IEnumerable<Skill> GetSkillsForUsers(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetAllSkillsForUser";

                var userId = new SqlParameter("@ID_USER", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(userId);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Skill
                    {
                        SkillId = (int)reader["id_skill"],
                        SkillName = (string)reader["Name"],
                        Comment = (string)reader["Comment"]
                    };
                }
            }
        }

        public int UpdateSkill(int id, string name, string comment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "UpdateSkill";

                var userid = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                var userName = new SqlParameter("@NAME", System.Data.SqlDbType.VarChar)
                {
                    Value = name
                };

                var userComment = new SqlParameter("@COMMENT", System.Data.SqlDbType.VarChar)
                {
                    Value = comment
                };

                command.Parameters.AddRange(new SqlParameter[] { userid, userName, userComment });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }
    }
}
