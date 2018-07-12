using System.Collections.Generic;
using Entity;

namespace Skills.BLL.Logic
{
    public interface IUserLogic
    {
        bool AddUser(User user);
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        bool UpdateUserForAdmin(int id, int role);
        bool UpdateuserForUsers(int id, string name);
        bool DeleteUser(int id);
    }
}