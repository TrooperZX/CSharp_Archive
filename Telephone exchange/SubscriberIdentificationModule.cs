using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TelephoneExchange
{
    public delegate void BalanceChangeByCompany(int sum, string _subscriberNumber);
    public class CardSIM
    {
        public event BalanceChangeByCompany withdrawMoneyCompany;
        public event BalanceChangeByCompany putMoneyCompany;

        public string _SubscriberNumber;
        public string SubscriberName;
        public BalanceAccount SubscriberCashBalance;
        public int DataPlanChangeCounter;
        public DataPlanGenaral DataPlan;
        public int UsedTalkMinutes;

        // 0 = no data, 1 = available for incoming and outcomming calls,
        // 2 =  available for incoming unavailable for outcomming calls,
        // 3 = unavalible for incoming and outcomming calls.
        public byte SubscriberModuleStatus;

        // True = online, False = offline.
        public bool SubscriberPhoneStatus;

        public CardSIM(string _subscriberNumber, string subscriberName
            , BalanceAccount subscriberCashBalance, int dataPlanChangeCounter
            , DataPlanGenaral dataPlan, int usedTalkMinutes, byte subscriberModuleStatus
            , bool subscriberPhoneStatus)
        {
            SubscriberPhoneStatus = subscriberPhoneStatus;
            dataPlan = new DataPlanGenaral("", "", 0, 0, 0);
            subscriberCashBalance = new BalanceAccount(500);
            _SubscriberNumber = _subscriberNumber;
            SubscriberName = subscriberName;
            SubscriberModuleStatus = subscriberModuleStatus;
            SubscriberCashBalance = subscriberCashBalance;
            DataPlanChangeCounter = dataPlanChangeCounter;
            DataPlan = dataPlan;
            UsedTalkMinutes = usedTalkMinutes;
        }
        // Printing client info to console.
        public void PrintInfo()
        {
            Console.WriteLine($"_SubscriberNumber = {_SubscriberNumber}");
            Console.WriteLine($"SubscriberName = {SubscriberName}");
            Console.WriteLine($"SubscriberCashBalance = {SubscriberCashBalance.Sum}");
            Console.WriteLine($"DataPlanChangeCounter = {DataPlanChangeCounter}");
            Console.WriteLine($"DataPlanName = {DataPlan.PlanName}");
            Console.WriteLine($"UsedTalkMinutes = {UsedTalkMinutes}");
            Console.WriteLine($"SubscriberModuleStatus = {SubscriberModuleStatus}");
            Console.WriteLine($"SubscriberPhoneStatus = {SubscriberPhoneStatus}");
            Console.WriteLine();
        }
        public void ChangeDataPlanWithdraw()
        {
            SubscriberCashBalance.Withdraw(DataPlan.PlanChargePerActiveMinute
            * UsedTalkMinutes + DataPlan.PlanChargePerMonth);
            DataPlanChangeCounter = 30;
            UsedTalkMinutes = 0;
        }
        public static void PutMoneyFromCompany(int sum, string _subscriberNumber)
        {
            Console.WriteLine($"{sum} money has beed added to account {_subscriberNumber}.");
        }
        public static void WithdrawMoneyFromCompany(int sum, string _subscriberNumber)
        {
            Console.WriteLine($"{sum} money has beed removed from account {_subscriberNumber}.");
        }
        public byte CheckSIMBalance(BalanceAccount SubscriberCashBalance, bool SubscriberPhoneStatus)
        {
            byte subscriberModuleStatus = 0;
            if (SubscriberPhoneStatus == true)
            {
                if (SubscriberCashBalance.Sum < 0)
                {
                    subscriberModuleStatus = 2;
                }
                else
                {
                    subscriberModuleStatus = 1;
                }
            }
            else
            {
                subscriberModuleStatus = 0;
            }
            return subscriberModuleStatus;
        }
    }
}

