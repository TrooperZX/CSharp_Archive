using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public delegate void BalanceChangeHandler(int sum);
    public class BalanceAccount
    {
        public event BalanceChangeHandler put;
        public event BalanceChangeHandler withdrawed;

        // Sum on account.
        public int Sum { get; private set; }

        // Initial sum on account.
        public BalanceAccount(int sum)
        {
            Sum = sum;
        }

        // Add money.
        public void Put(int sum)
        {
            Sum += sum;
            if (sum != 0)
            {
                put(sum);
            }
        }

        // Remove money.
        public void Withdraw(int sum)
        {
            Sum -= sum;
            if (sum!=0)
            {
                withdrawed(sum);
            }
        }

        // Notification to client.
        public static void PutMoney(int sum)
        {
            Console.WriteLine($"Client notification: {sum} money has beed added to account.");
        }
        public static void WithdrawMoney(int sum)
        {
            Console.WriteLine($"Client notification: {sum} money has beed removed from account.");
        }
    }
}
