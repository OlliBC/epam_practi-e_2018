using BLL.Logging;
using Entity;
using Skills.DAL.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skills.BLL.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;
        private readonly Logging logging;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
            logging = new Logging();
        }

        public bool AddUser(User user)
        {
            _userDao.AddUser(user);

            logging.WriteLoggingInFile($"Добавили пользователя {user.UserId}");

            return true;
        }

        public bool DeleteUser(int id)
        {
            _userDao.DeleteUser(id);

            logging.WriteLoggingInFile($"Удалили пользователя {id}");

            return true;
        }

        public User GetUserById(int id)
        {
            logging.WriteLoggingInFile($"Нашли пользователя {id}");

            return _userDao.GetUserById(id);
        }

        public IEnumerable<User> GetUsers()
        {
            logging.WriteLoggingInFile($"Вывели пользователей");

            return _userDao.GetUsers().ToList();
        }

        public bool UpdateUserForAdmin(int id, int role)
        {
            _userDao.UpdateUserForAdmin(id, role);

            logging.WriteLoggingInFile($"Обновили роль пользователя {id}");

            return true;
        }

        public bool UpdateuserForUsers(int id, string name)
        {
            _userDao.UpdateUserForUsers(id, name);

            logging.WriteLoggingInFile($"Обновили имя пользователя {id}");

            return true;
        }
    }
}
