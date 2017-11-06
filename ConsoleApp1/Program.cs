using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary2;
using Factories;
using IFactory;
using Ninject;
using Modules;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //example of 
                IKernel kernel = new StandardKernel();
                kernel.Bind<IEmailSender>().To<AnEmailSender>().InTransientScope();
                kernel.Bind<BulkEmailSender>().ToMethod(context =>
                    new BulkEmailSender(context.Kernel.Get<IEmailSender>(), "my footer")).InSingletonScope();

                var b1 = kernel.Get<BulkEmailSender>();
                var b2 = kernel.Get<BulkEmailSender>();

                Debug.Assert(ReferenceEquals(b1, b2));

                var e1 = kernel.Get<IEmailSender>();
                var e2 = kernel.Get<IEmailSender>();
                Debug.Assert(!ReferenceEquals(e1, e2));


                 kernel = new StandardKernel();
                kernel.Bind<IEmailSender>().To<AnEmailSender>();
                kernel.Bind<IEmailSenderFactory>().To<EmailSenderFactory>().InSingletonScope();
                kernel.Bind<IBulkEmailSenderFactory>().To<BulkEmailSenderFactory>().InSingletonScope();

                var factory = kernel.Get<IBulkEmailSenderFactory>();
                var bulkEmailSender = factory.Create("Bye");

                kernel.Bind<Samurai>().ToSelf();
                kernel.Get<Samurai>().Attack("your enemy");

                kernel = new StandardKernel(new WarriorModule());
                kernel = new StandardKernel();
                var dir = Directory.GetCurrentDirectory();
                //kernel.Load<Modules.AnEmailSenderModule>();
                kernel.Load("*.dll");
                var emailSender = kernel.Get<IEmailSender>();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
           
        }
    }
}
