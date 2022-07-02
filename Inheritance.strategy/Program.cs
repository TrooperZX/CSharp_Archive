namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            var farm1 = new FactoryUnitMilitia("Horns and Hooves");
            var militiaUnit0_1 = farm1.Create();
            var militiaUnit0_2 = farm1.Create();

            var barrack1 = new FactoryUnitFootman("Form up!");
            var footmanUnit0_1 = barrack1.Create();

            var trainingGrounds1 = new FactoryUnitKnight("Giddy up!");
            var knightUnit0_1 = trainingGrounds1.Create();
            var knightUnit0_2 = trainingGrounds1.Create();
            var knightUnit0_3 = trainingGrounds1.Create();

            var RosterUnit = new Unit[]
            {
            militiaUnit0_1,  knightUnit0_1, footmanUnit0_1, knightUnit0_2, militiaUnit0_2, knightUnit0_3
            };
            // Counter for roster upkeep, with counter "armyUpkeep".
            var armyUpkeep = 0;
            foreach (var Unit in RosterUnit)
            {
                armyUpkeep += Unit.Cost;
                Console.WriteLine($"Name = {Unit.Name}");
                Console.WriteLine($"Attack points = {Unit.AttackPoint}");
                Console.WriteLine($"Maintanance cost = {Unit.Cost}");
                Console.WriteLine($"Health points =  {Unit.HealthPoint}\n");
            }
            Console.WriteLine($"There are {RosterUnit.Length} units in the roster.");
            Console.WriteLine($"Current army upkeep are: {armyUpkeep} coins.\n\n");
            Console.WriteLine($"Press any key to continue...");
            Console.ReadLine();

            // Sorting roster array by attack points.
            Console.WriteLine("Sorting roster of units by attack points.\n");
            Array.Sort(RosterUnit, Unit.CompareByAttackPoints);
            foreach (var Unit in RosterUnit)
            {
                Console.WriteLine($"{Unit.Name}");
            }
            Console.WriteLine("\nSorting complete.\n\n");
            Console.WriteLine($"Press any key to continue...");
            Console.ReadLine();

            // Finding unit in roster by specifically ammount of health points
            Console.WriteLine("Finding unit in roster by specifically ammount of health points(6-8)\n");
            var i = 0;
            var selectedHealthPoints = RosterUnit.Where(x => x.HealthPoint > 5 && x.HealthPoint < 9);
            foreach (Unit RosterUnit2 in selectedHealthPoints)
            {
                i++;
                Console.WriteLine($"Name = {RosterUnit2.Name}");
                Console.WriteLine($"Attack points = {RosterUnit2.AttackPoint}");
                Console.WriteLine($"Maintanance cost = {RosterUnit2.Cost}");
                Console.WriteLine($"Health points =  {RosterUnit2.HealthPoint}\n");
            }
            if (i == 0)
            {
                Console.WriteLine("There are no units with selected health points in the roaster.");
            }
            else if (i == 1)
            {
                Console.WriteLine("There are only one unit with selected health points in the roaster.");
            }
            else
            {
                Console.WriteLine($"There are {i} units with selected health points in the roaster.");
            }
            Console.WriteLine("Searching unit with specified  ammount of health points complete.");
        }
    }
}