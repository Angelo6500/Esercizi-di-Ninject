using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IEmailSender
    {
        bool SendEmail(string to, string body);
    }

    public interface IBulkEmailSender
    {

    }


    public interface IWeapon
    {
        string Hit(string target);
    }
}
