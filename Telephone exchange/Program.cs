using System.Text;
using System.Collections.Generic;
namespace TelephoneExchange
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Data lists of all SIM of the clients, and all phones.
            var clientDataList = new List<CardSIM>();
            var clientPhoneList = new List<Phone>();
            Dictionary<string, List<string>> clientHistoryDict = new Dictionary<string, List<string>>();

            // Pseudorandom number generator for phone number.
            var numberRandomGenerator = new NumberGenerator();

            // Data plans of the company.
            var dataPlan1 = new DataPlanExpencive();
            var dataPlan2 = new DataPlanCheap();

            // Callendary date.
            var date = new DateAndTime();
            var day = date.CurrentDay();

            for (int menuExitLoopSwitch = 0; menuExitLoopSwitch < 1;)
            {
                Console.Clear();
                Menu();
                Console.WriteLine("Enter menu number to continue...");
                var input = Console.ReadLine();
                var userinputCheck = int.TryParse(input, out var inputNumber);
                switch (input)
                {
                    // Regestration of new  client account.
                    case "1":
                        {
                            // Check and regenerate number if phone number allready occupied by another client.
                            var randomNumber = "";
                            do
                            {
                                randomNumber = numberRandomGenerator.NameSIM();
                            } while (clientDataList.Any(x => x._SubscriberNumber == randomNumber));

                            var balanceAccount = new BalanceAccount(0);
                            var clientAccount = new CardSIM(randomNumber, $"ClientName{clientDataList.Count + 1}" +
                                $" ClientSurname{clientDataList.Count + 1}",
                                balanceAccount, 30, dataPlan1, 0, 0, false);

                            // Set different data plans for clients.
                            if ((clientDataList.Count + 1) % 2 == 0)
                            {
                                clientAccount.DataPlanChangeCounter = 0;
                                clientAccount.DataPlan = dataPlan1;
                            }
                            else
                            {
                                clientAccount.DataPlan = dataPlan2;
                            }
                            // Events for notifiation of clients.
                            clientAccount.SubscriberCashBalance.put += BalanceAccount.PutMoney;
                            clientAccount.SubscriberCashBalance.withdrawed += BalanceAccount.WithdrawMoney;

                            // Generate of 'databases'of clients and clients phones.   
                            var clientPhone = new Phone(false, clientAccount._SubscriberNumber);
                            clientDataList.Add(clientAccount);
                            clientPhoneList.Add(clientPhone);
                            var clientHistoryList = new List<string>();
                            clientHistoryDict.Add(clientAccount._SubscriberNumber, clientHistoryList);
                            Console.WriteLine("A new client has been added to the base, his data is following:\n");
                            clientAccount.PrintInfo();
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }

                    // Fee for used service every 15th of the month.
                    case "2":
                        {
                            if (clientDataList.Count == 0)
                            {
                                Console.WriteLine("Not enough clients to proceed. Try add more clients first.");
                            }
                            else
                            {
                                day = 15; // For testing purposes.
                                if (day == 15)
                                {
                                    clientDataList.ForEach(c => Console.WriteLine($"{c._SubscriberNumber} has " +
                                        $"{c.SubscriberCashBalance.Sum} before commision payment."));
                                    clientDataList.ForEach(c => c.SubscriberCashBalance
                                    .Withdraw(c.DataPlan.PlanChargePerMonth + c.DataPlan.PlanChargePerActiveMinute
                                    * c.UsedTalkMinutes));

                                    // Bonusback for each talked minute.
                                    clientDataList.ForEach(c => c.SubscriberCashBalance
                                    .Put(c.DataPlan.PlanBonus * c.UsedTalkMinutes));
                                    clientDataList.ForEach(c => c.UsedTalkMinutes = 0);

                                    // Refresh SIM status, clear old history.
                                    foreach (var client in clientDataList)
                                    {
                                        client.SubscriberModuleStatus = client.CheckSIMBalance(client
                                            .SubscriberCashBalance, client.SubscriberPhoneStatus);
                                        clientHistoryDict[client._SubscriberNumber].Clear();
                                    }
                                }
                                clientDataList.ForEach(c => Console.WriteLine($"{c._SubscriberNumber} has " +
                                    $"{c.SubscriberCashBalance.Sum} after commision payment."));
                                day = date.CurrentDay();
                                Console.WriteLine("Press enter to continue...");
                            }
                            Console.ReadLine();
                            break;
                        }

                    // Changing data plan of the client.
                    case "3":
                        {
                            // Emulate desire of the client to change the data plan
                            Random testingRandom = new Random();
                            int i = testingRandom.Next(0, clientDataList.Count);
                            int j = testingRandom.Next(1, 2);
                            var BufferChanger = new DataPlanGenaral();
                            if (j == 1)
                            {
                                BufferChanger = new DataPlanCheap();
                            }
                            else
                            {
                                BufferChanger = new DataPlanExpencive();
                            }
                            try
                            {
                                Console.WriteLine($"Find client for change data plan, his properties are following:\n");
                                clientDataList[i].PrintInfo();
                                Console.WriteLine($"He want to change his data plan to following: {BufferChanger.PlanName}");
                                if (clientDataList[i].DataPlanChangeCounter > 0)
                                {
                                    Console.WriteLine($"He allready changed his data plan recently, he can change it after " +
                                        $"{clientDataList[i].DataPlanChangeCounter} days");
                                }
                                else
                                {
                                    if (clientDataList[i].SubscriberCashBalance.Sum <= 0)
                                    {
                                        Console.WriteLine("He can't change his data plan with negatve balance.");
                                    }
                                    else
                                    {
                                        if (clientDataList[i].DataPlan != BufferChanger)
                                        {
                                            clientDataList[i].SubscriberModuleStatus = clientDataList[i]
                                                .CheckSIMBalance(clientDataList[i].SubscriberCashBalance
                                                , clientDataList[i].SubscriberPhoneStatus);

                                            clientDataList[i].DataPlan = BufferChanger;
                                            clientDataList[i].ChangeDataPlanWithdraw();
                                            Console.WriteLine();
                                            Console.WriteLine("Client data plan chenge sucessful, new data of the client are:");
                                            clientDataList[i].PrintInfo();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Client try to change data plan to which he allready has, " +
                                                "operation aborted");
                                        }
                                    }
                                }
                            }
                            catch (ArgumentOutOfRangeException err)
                            {
                                Console.WriteLine("Need more clients for this function to work properly. " +
                                    "Try adding new client first.");
                            }
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                    // Emulate of client action of turn on the phone.
                    case "4":
                        {
                            try
                            {
                                Random testingRandom = new Random();
                                int i = testingRandom.Next(0, clientDataList.Count);
                                Console.WriteLine($"Client {clientDataList[i]._SubscriberNumber} with following number " +
                                    $"is wanting to switch on his phone:\n");
                                clientPhoneList[i].SwitchPhoneOn();
                                clientDataList[i].SubscriberPhoneStatus = clientPhoneList[i].PowerSwitch;
                                clientDataList[i].SubscriberModuleStatus = clientDataList[i]
                                    .CheckSIMBalance(clientDataList[i].SubscriberCashBalance, clientDataList[i].SubscriberPhoneStatus);
                                clientDataList[i].PrintInfo();
                            }
                            catch (ArgumentOutOfRangeException err)
                            {
                                Console.WriteLine("Need more clients for this function to work properly. " +
                                    "Try adding new client first.");
                            }
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                    // Emulate of client action of turn off the phone.
                    case "5":
                        {
                            try
                            {
                                Random testingRandom = new Random();
                                int i = testingRandom.Next(0, clientDataList.Count);
                                Console.WriteLine($"Client {clientDataList[i]._SubscriberNumber} " +
                                    $"with following number is wanting to switch off his phone:\n");
                                clientPhoneList[i].SwitchPhoneOff();
                                clientDataList[i].SubscriberPhoneStatus = clientPhoneList[i].PowerSwitch;
                                clientDataList[i].SubscriberModuleStatus = clientDataList[i]
                                    .CheckSIMBalance(clientDataList[i].SubscriberCashBalance, clientDataList[i].SubscriberPhoneStatus);
                                clientDataList[i].PrintInfo();
                            }
                            catch (ArgumentOutOfRangeException err)
                            {
                                Console.WriteLine("Need more clients for this function to work properly. " +
                                    "Try adding new client first.");
                            }
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }
                    // Emulate of the calling [0] client to another client, client [1] allways unreachable.
                    case "6":
                        {
                            try
                            {
                                clientPhoneList[0].PowerSwitch = true;
                                clientDataList[0].SubscriberPhoneStatus = clientPhoneList[0].PowerSwitch;
                                clientDataList[0].SubscriberModuleStatus = clientDataList[0]
                                    .CheckSIMBalance(clientDataList[0].SubscriberCashBalance, clientDataList[0].SubscriberPhoneStatus);

                                // For testing purposes next 3 lines.
                                clientPhoneList[1].PowerSwitch = true;
                                clientDataList[1].SubscriberPhoneStatus = clientPhoneList[1].PowerSwitch;
                                clientDataList[1].SubscriberModuleStatus = 3;

                                clientDataList.ForEach(c => Console.WriteLine($"{c._SubscriberNumber}"));
                                Console.WriteLine("Copy and enter phone of existed client to try to make a call...");
                                var number = Console.ReadLine();
                                var resoult = clientDataList.SingleOrDefault(c => c._SubscriberNumber == number);
                                if (resoult == null)
                                {
                                    Console.WriteLine("Wrong number dialed. Please enter correct number.");
                                }
                                else
                                {
                                    var pos = clientDataList.IndexOf(resoult);
                                    if (clientDataList[0].SubscriberModuleStatus != 1 || clientDataList[0].SubscriberCashBalance.Sum <= 0)
                                    {
                                        Console.WriteLine("Connot establish the connction. Negative balance or some other error acquired.");
                                    }
                                    else
                                    {
                                        // Starting a call.
                                        if (clientDataList[pos].SubscriberModuleStatus == 1 || clientDataList[pos].SubscriberModuleStatus == 2)
                                        {
                                            // Make callers unavalible for others.
                                            clientDataList[0].SubscriberModuleStatus = clientDataList[pos].SubscriberModuleStatus = 3;

                                            // Emulate of the call length duration.
                                            Random testingConnection = new Random();
                                            int i = testingConnection.Next(0, 3600);
                                            Console.WriteLine($"Established connection between {clientDataList[0]._SubscriberNumber} " +
                                                $"and {clientDataList[pos]._SubscriberNumber} was last {i} seconds");

                                            // Restore callers sim status.
                                            clientDataList[0].SubscriberModuleStatus = clientDataList[0].
                                                CheckSIMBalance(clientDataList[0].SubscriberCashBalance, clientDataList[0].SubscriberPhoneStatus);
                                            clientDataList[pos].SubscriberModuleStatus = clientDataList[pos].
                                                CheckSIMBalance(clientDataList[pos].SubscriberCashBalance, clientDataList[pos].SubscriberPhoneStatus);
                                            clientDataList[1].SubscriberModuleStatus = clientDataList[1].
                                                CheckSIMBalance(clientDataList[1].SubscriberCashBalance, clientDataList[1].SubscriberPhoneStatus);

                                            clientDataList[0].UsedTalkMinutes += (i / 60) + 1;

                                            // Add information about the call to caller history.
                                            var line = new CallHistoryLine(clientDataList[0]._SubscriberNumber
                                                , clientDataList[pos]._SubscriberNumber, i
                                                , clientDataList[0].DataPlan.PlanChargePerActiveMinute * i);

                                            clientHistoryDict[clientDataList[0]._SubscriberNumber].Add(
                                            line.MakeARecord(clientDataList[0]._SubscriberNumber,
                                            clientDataList[pos]._SubscriberNumber, i, clientDataList[0]
                                            .DataPlan.PlanChargePerActiveMinute * i, true));

                                            // Add information about the call to receiving call history.
                                            line = new CallHistoryLine(clientDataList[pos]._SubscriberNumber
                                                , clientDataList[0]._SubscriberNumber, i
                                                , clientDataList[pos].DataPlan.PlanChargePerActiveMinute * i);

                                            clientHistoryDict[clientDataList[pos]._SubscriberNumber].Add(
                                            line.MakeARecord(clientDataList[pos]._SubscriberNumber,
                                            clientDataList[0]._SubscriberNumber, i, clientDataList[pos]
                                            .DataPlan.PlanChargePerActiveMinute * i, false));

                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine("The cell phone you are trying to reach is switched off or out of range.");
                                            Console.ReadLine();
                                        }
                                    }
                                }
                            }
                            catch (ArgumentOutOfRangeException err)
                            {
                                Console.WriteLine("\nNeed more clients for this function to work properly." +
                                    "Need at least 3 clients in data base. Try adding new client first.");
                            }
                            Console.ReadLine();
                            break;
                        }
                    // Emulate of replenishment of funds on [0] client.
                    case "7":
                        try
                        {
                            Console.WriteLine("Which amount of money you want to add to your account:");
                            input = Console.ReadLine();
                            userinputCheck = int.TryParse(input, out inputNumber);
                            if (userinputCheck)
                            {
                                clientDataList[0].SubscriberCashBalance.Put(inputNumber);
                            }
                            else
                            {
                                Console.WriteLine("You can only put integer money count on your account.");
                            }
                            // Recheck caller sim status.
                            clientDataList[0].SubscriberModuleStatus = clientDataList[0].CheckSIMBalance(clientDataList[0]
                                .SubscriberCashBalance, clientDataList[0].SubscriberPhoneStatus);
                        }
                        catch (ArgumentOutOfRangeException err)
                        {
                            Console.WriteLine("Need more clients for this function to work properly. Try adding new client first.");
                        }
                        Console.ReadLine();
                        break;

                    // Emulate of replenishment of funds on any client.
                    case "8":
                        try
                        {
                            Console.WriteLine("Which amount of money you want to add to account:");
                            input = Console.ReadLine();
                            userinputCheck = int.TryParse(input, out int inputMoney);
                            if (userinputCheck && inputMoney > 0)
                            {
                                Console.WriteLine("To which account you want to add money?");
                                Console.WriteLine($"You need to chose client from 0 to {clientDataList.Count}");
                                input = Console.ReadLine();
                                userinputCheck = int.TryParse(input, out int inputClient);

                                if (userinputCheck && inputClient >= 0)
                                {
                                    clientDataList[inputClient].SubscriberCashBalance.Put(inputMoney);
                                    // Recheck caller sim status.
                                    clientDataList[inputClient].SubscriberModuleStatus = clientDataList[0]
                                        .CheckSIMBalance(clientDataList[inputClient].SubscriberCashBalance
                                        , clientDataList[inputClient].SubscriberPhoneStatus);
                                }
                            }
                            else
                            {
                                Console.WriteLine("You can only put positive integer money count on account.");
                            }
                        }
                        catch (ArgumentOutOfRangeException err)
                        {
                            Console.WriteLine("Need more clients for this function to work properly. Try adding new client first.");
                        }
                        Console.ReadLine();
                        break;

                    // Emulate of caller call history.
                    case "9":

                        try
                        {
                            if (clientHistoryDict[clientDataList[0]._SubscriberNumber].Count == 0)
                            {
                                Console.WriteLine("No data of recent calls.");
                                Console.WriteLine("-------------------------------------------------------------------------");
                            }
                            else
                            {
                                foreach (var historyLine in clientHistoryDict[clientDataList[0]._SubscriberNumber])
                                {
                                    Console.WriteLine("   Time of the call |  Interlocutor | Type of call | Call dur-on | Callcost");
                                    Console.WriteLine(historyLine);
                                    Console.WriteLine("-------------------------------------------------------------------------");
                                }
                            }
                            Console.ReadLine();
                        }
                        catch (ArgumentOutOfRangeException err)
                        {
                            Console.WriteLine("Need more clients for this function to work properly. Try adding new client first.");
                        }
                        Console.ReadLine();
                        break;

                    // Print info about all clients.
                    case "0":
                        if (clientDataList.Count == 0)
                        {
                            Console.WriteLine("No clients detected.");
                        }
                        else
                        {
                            clientDataList.ForEach(c => c.PrintInfo());
                        }
                        Console.ReadLine();
                        break;

                    // Exit of program.
                    case "x":
                        menuExitLoopSwitch = 1;
                        break;

                    case "X":
                        menuExitLoopSwitch = 1;
                        break;
                }
            }
        }
        static void Menu()
        {
            Console.WriteLine("1  - Add new client to the base.");
            Console.WriteLine("2  - Testing of montly commission payments.");
            Console.WriteLine("3  - Changing plan of the random client.");
            Console.WriteLine("4  - Changing phone status of random client(on).");
            Console.WriteLine("5  - Changing phone status of random client(off).");
            Console.WriteLine("6  - Calling to some one.");
            Console.WriteLine("7  - Putting money on balance account.");
            Console.WriteLine("8  - Putting money on balance account.");
            Console.WriteLine("9  - History of calls.");
            Console.WriteLine("0  - Print clients data in console.");
            Console.WriteLine("x  - Exit of program.");
        }
    }
}
