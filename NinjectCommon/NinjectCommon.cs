using Ninject;
using Skills.BLL.Logic;
using Skills.DAL.DAO;

namespace NinjectCommon
{
    public static class NinjectCommon
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static IKernel Kernel => _kernel;

        public static void Registration()
        {
            _kernel.Bind<IUserDao>().To<UserDao>();
            _kernel.Bind<IUserLogic>().To<UserLogic>();

            _kernel.Bind<ISkillDao>().To<SkillDao>();
            _kernel.Bind<ISkillLogic>().To<SkillLogic>();
        }
    }
}
