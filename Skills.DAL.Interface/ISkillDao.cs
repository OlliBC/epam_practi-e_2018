using System.Collections.Generic;
using Entity;

namespace Skills.DAL.DAO
{
    public interface ISkillDao
    {
        void AddSkill(int id, Skill skill);
        IEnumerable<Skill> GetSkills();
        Skill GetSkillById(int id);
        int UpdateSkill(int id, string name, string comment);
        int DeleteSkill(int id);
        IEnumerable<Skill> GetSkillsForUsers(int id);
    }
}