using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace IFactory
{
    public interface IEmailSenderFactory
    {
        IEmailSender Create();
    }

    public interface IBulkEmailSenderFactory
    {
        IBulkEmailSender Create(string footer);
    }


}
