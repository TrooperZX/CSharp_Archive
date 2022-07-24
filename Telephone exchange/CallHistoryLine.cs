using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class CallHistoryLine
    {
        string OwnerNumber;
        string InterlocutorNumber;
        int CallDuration;
        int CallPrice;
        public CallHistoryLine(string ownerNumber, string interlocutorNumber, int callDuration, int callPrice)
        {
            OwnerNumber = ownerNumber;
            InterlocutorNumber = interlocutorNumber;
            CallDuration = callDuration;
            CallPrice = callPrice;
        }
        public string MakeARecord(string ownerNumber, string interlocutorNumber, int callDuration, int callPrice, bool ingoing)
        {
            var date = new DateAndTime();
            var time = date.DateOfCall();
            var linkDuration = date.CallingDuration(callDuration);
            string recordLine = $"";
            if (ingoing)
            {
                recordLine = $"{time} -- {interlocutorNumber} -- Is ingoing -- {linkDuration} -- {callPrice}";
            }
            else
            {
                recordLine = $"{time} -- {ownerNumber} -- Is outgoing -- {linkDuration}";
            }
            return recordLine;
        }
    }
}
