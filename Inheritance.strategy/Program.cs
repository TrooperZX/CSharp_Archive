namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            var Farm1 = new FactoryUnitMilitia("Horns and Hooves");
            var MilitiaUnit0_1 = Farm1.Create();
            var MilitiaUnit0_2 = Farm1.Create();

            var Barrack1 = new FactoryUnitFootman("Form up!");
            var FootmanUnit0_1 = Barrack1.Create();

            var TrainingGrounds1 = new FactoryUnitKnight("Giddy up!");
            var KnightUnit0_1 = TrainingGrounds1.Create();
            var KnightUnit0_2 = TrainingGrounds1.Create();
            var KnightUnit0_3 = TrainingGrounds1.Create();

            var RosterUnit = new Unit[]
            {
            MilitiaUnit0_1,  KnightUnit0_1, FootmanUnit0_1, KnightUnit0_2, MilitiaUnit0_2, KnightUnit0_3
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