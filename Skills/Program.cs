using Entity;
using Ninject;
using NinjectCommon;
using Skills.BLL.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skills
{
    class Program
    {

        private static IUserLogic userLogic;
        private static ISkillLogic skillLogic;

        static void Main(string[] args)
        {
            NinjectCommon.NinjectCommon.Registration();

            userLogic = NinjectCommon.NinjectCommon.Kernel.Get<IUserLogic>();
            skillLogic = NinjectCommon.NinjectCommon.Kernel.Get<ISkillLogic>();

            //userLogic.AddUser(new User { UserId = 3, Name = "Petr", Password = "123", Role = 3 });
            //skillLogic.AddSkill(new Skill { SkillId = 2, SkillName = "Python", Comment = "Normal" });

            //Console.WriteLine("USERS: ");
            //foreach (var item in userLogic.GetUsers())
            //{
            //    Console.WriteLine($"{item.UserId} : {item.Name} : {item.Role} ");
            //}

            //Console.WriteLine();

            //Console.WriteLine("SKILLS: ");
            //foreach (var item in skillLogic.GetSkills())
            //{
            //    Console.WriteLine($"{item.SkillId} : {item.SkillName} : {item.Comment}");
            //}

            //Console.WriteLine();

            foreach (var item in skillLogic.GetSkillsForUser(1))
            {
                Console.WriteLine($"{item.SkillName} : {item.Comment}");
            }

            //skillLogic.AddSkill(1, new Skill { SkillId = 1, SkillName = "Sleeper", Comment = "Good Boy" });

            //Console.WriteLine("SKILLS: ");
            //foreach (var item in skillLogic.GetSkills())
            //{
            //    Console.WriteLine($"{item.SkillId} : {item.SkillName} : {item.Comment}");
            //}


            //userLogic.UpdateUserForAdmin(1, 2);
            //userLogic.UpdateuserForUsers(1, "Davidka");

            //skillLogic.UpdateSkill(1, "C#", "More than zero");

            //userLogic.DeleteUser(4);
            //skillLogic.DeleteSkill(3);

            //var user = userLogic.GetUserById(1);

            //Console.WriteLine(user.Name);

            //var skill = skillLogic.GetSkillById(1);

            //Console.WriteLine(skill.SkillName);



            Console.ReadKey();
        }
    }
}
