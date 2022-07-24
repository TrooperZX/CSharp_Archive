using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class DataPlanGenaral
    {
        public string PlanName;
        public string PlanDescription;
        public int PlanChargePerMonth;
        public int PlanChargePerActiveMinute;
        public int PlanBonus;

        public DataPlanGenaral(string planName = "DataPlane_Name", string planDescription ="DataPlane_Description",
            int planChargePerMonth =0,int planChargePerActiveMinute =0, int planBonus =0)
        {
            this.PlanName = planName;
            this.PlanDescription = planDescription;
            this.PlanChargePerMonth = planChargePerMonth;
            this.PlanChargePerActiveMinute = planChargePerActiveMinute;
            this.PlanBonus = planBonus;
        }
    }
}
