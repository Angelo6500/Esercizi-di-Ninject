using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary2;
using Ninject.Modules;

namespace Modules
{
    public class WarriorModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWeapon>().To<Sword>();
            this.Bind<Samurai>().ToSelf().InSingletonScope();

        }
    }

    public class AnEmailSenderModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEmailSender>().To<AnEmailSender>();
        }
    }
}
