using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Phone
    {
        public bool PowerSwitch;
        public string PhoneNumber;
        public Phone(bool powerSwitch, string phoneNumber)
        {
            PowerSwitch = powerSwitch = false;
            PhoneNumber = phoneNumber;
        }
        public void SwitchPhoneOn()
        {
            if(PowerSwitch != true)
            {
                PowerSwitch = true;
                var subscriberPhoneStatus = PowerSwitch;
                Console.WriteLine("Phone is online.");
            }
            else
            {
                Console.WriteLine("Phone is allready on.");
            }
        }
        public void SwitchPhoneOff()
        {
            if (PowerSwitch != false)
            {
                PowerSwitch = false;
                var subscriberPhoneStatus = PowerSwitch;
                Console.WriteLine("Phone is offline.");
            }
            else
            {
                Console.WriteLine("Phone is allready off.");
            }
        }

    }
}
