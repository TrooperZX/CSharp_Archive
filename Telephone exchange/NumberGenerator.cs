using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class NumberGenerator
    {
        public string NameSIM()
        {
            Random rand = new Random();
            int code = rand.Next(551, 569);
            int num = rand.Next(100, 999);
            int num2 = rand.Next(10, 99);
            int num3 = rand.Next(10, 99);
            string subName = "+" + code.ToString() + " " + num.ToString() + " " + num2.ToString() + " " + num3.ToString();
            return subName;
        }
    }
}


