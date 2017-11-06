using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ClassLibrary2
{
    public class AnEmailSender : IEmailSender
    {
        public bool SendEmail(string to, string body)
        {
            
            Console.WriteLine("Sending mail to {0}",to);
            return true;

        }
    }
    

    public class BulkEmailSender : IBulkEmailSender
    {
        private readonly IEmailSender _emailSender;
        private readonly string _footer;
        public BulkEmailSender(IEmailSender emailSender, string footer)
        {
            this._emailSender = emailSender;
            this._footer = String.Empty;
        }
        public void SendEmail(List<string> addresses, string body) {/*…*/}
    }



    public class Sword : IWeapon
    {
        public string Hit(string target)
        {
            return "Slice " + target + " in half";
        }
    }

    public class Dagger : IWeapon
    {
        public string Hit(string target)
        {
            return "Slice " + target + " to death";
        }
    }


    public class Samurai
    {
        private readonly IEnumerable<IWeapon> allWeapons;

        public Samurai(IWeapon[] allWeapons)
        {
            this.allWeapons = allWeapons;
        }

        public void Attack(string target)
        {
            foreach (var weapon in this.allWeapons)
            {
                Console.WriteLine(weapon.Hit(target));
            }
        }

    }

}
