using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary2;
using IFactory;

namespace Factories
{
    public class EmailSenderFactory : IEmailSenderFactory
    {
        public IEmailSender Create()
        {
            return new AnEmailSender();
        }
    }


    public class BulkEmailSenderFactory : IBulkEmailSenderFactory
    {

        private readonly IEmailSenderFactory _emailSenderFactory;

        public BulkEmailSenderFactory(IEmailSenderFactory emailSenderFactory)
        {
            this._emailSenderFactory = emailSenderFactory;
        }


        public IBulkEmailSender Create(string footer)
        {
            return new BulkEmailSender(this._emailSenderFactory.Create(),footer);
        }

    }




}
