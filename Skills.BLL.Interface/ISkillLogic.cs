using System.Collections.Generic;
using Entity;

namespace Skills.BLL.Logic
{
    public interface ISkillLogic
    {
        bool AddSkill(int id, Skill skill);
        IEnumerable<Skill> GetSkills();
        Skill GetSkillById(int id);
        bool UpdateSkill(int id, string name, string comment);
        bool DeleteSkill(int id);
        IEnumerable<Skill> GetSkillsForUser(int id);
    }
}