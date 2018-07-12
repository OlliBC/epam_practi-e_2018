using System.Collections.Generic;
using Entity;

namespace Skills.DAL.DAO
{
    public interface IUserDao
    {
        int AddUser(User user);
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        int UpdateUserForUsers(int id, string name);
        int UpdateUserForAdmin(int id, int role);
        int DeleteUser(int id);
    }
}