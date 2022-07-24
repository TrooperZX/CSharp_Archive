using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class DataPlanExpencive : DataPlanGenaral
    {
        public DataPlanExpencive()
             : base()
        {
            this.PlanName = "Expancive dataplane";
            this.PlanDescription = "Very expencive and luxary data plane for all of your need's.";
            this.PlanChargePerMonth = 10000;
            this.PlanChargePerActiveMinute = 100;
            this.PlanBonus = 20;
        }
    }
}
