using BLL.Logging;
using Entity;
using Skills.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skills.BLL.Logic
{
    public class SkillLogic : ISkillLogic
    {
        private readonly ISkillDao _skillDao;
        private readonly Logging logging;

        public SkillLogic(ISkillDao skillDao)
        {
            _skillDao = skillDao;
            logging = new Logging();
        }

        public bool AddSkill(int id, Skill skill)
        {
            _skillDao.AddSkill(id, skill);

            logging.WriteLoggingInFile($"Добавили навык {skill.SkillId}");

            return true;
        }

        public IEnumerable<Skill> GetSkills()
        {
            logging.WriteLoggingInFile($"Вывели навыки");

            return _skillDao.GetSkills().ToList();
        }

        public Skill GetSkillById(int id)
        {
            logging.WriteLoggingInFile($"Нашли навык {id}");

            return _skillDao.GetSkillById(id);
        }

        public bool UpdateSkill(int id, string name, string comment)
        {
            _skillDao.UpdateSkill(id, name, comment);

            logging.WriteLoggingInFile($"Обновили название и коммент навыка {id}");

            return true;
        }

        public bool DeleteSkill(int id)
        {
            _skillDao.DeleteSkill(id);

            logging.WriteLoggingInFile($"Удалили навык {id}");

            return true;
        }

        public IEnumerable<Skill> GetSkillsForUser(int id)
        {
            logging.WriteLoggingInFile($"Вывели список медали для пользователя {id}");

            return _skillDao.GetSkillsForUsers(id);
        }
    }
}
