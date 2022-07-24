using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class DateAndTime
    {
        DateTime currentDate = DateTime.UtcNow;
        public int CurrentDay()
        {
            var currentDay = currentDate.Day;
            return currentDay;
        }
        public string DateOfCall()
        {
            var currentTime = currentDate;
            return currentTime.ToString("MM/dd/yyyy HH:mm:ss");
        }
        public string CallingDuration(int callDuration)
        {
            var currentTime =currentDate.AddSeconds(callDuration) - currentDate;
            return currentTime.ToString("c");
        }
    }
}
