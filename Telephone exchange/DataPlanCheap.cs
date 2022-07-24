using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class DataPlanCheap : DataPlanGenaral
    {
        public DataPlanCheap()
             : base()
        {
            this.PlanName = "Cheap dataplane";
            this.PlanDescription = "Very cheap and frugal data plane for basic necessities.";
            this.PlanChargePerMonth = 5000;
            this.PlanChargePerActiveMinute = 200;
            this.PlanBonus = 0;
        }
    }
}
