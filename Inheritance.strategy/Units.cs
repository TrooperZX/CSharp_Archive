namespace Homework3
{
    // Abstract class of traning unit.
    abstract public class FactoryUnit
    {
        public string Name 
        { 
            get; set; 
        }

        public FactoryUnit(string n)
        {
            Name = n;
        }
        // Factory method.
        abstract public Unit Create();
    }

    // Factory for militia.
    public class FactoryUnitMilitia : FactoryUnit
    {
        public FactoryUnitMilitia(string n) : base(n)
        { }

        public override Unit Create()
        {
            return new Militia();
        }
    }

    // Factory for footman.
    public class FactoryUnitFootman : FactoryUnit
    {
        public FactoryUnitFootman(string n) : base(n)
        { }

        public override Unit Create()
        {
            return new Footman();
        }
    }

    // Factory for knight.
    public class FactoryUnitKnight : FactoryUnit
    {
        public FactoryUnitKnight(string n) : base(n)
        { }

        public override Unit Create()
        {
            return new Knight();
        }
    }

    // Unit Classes.General.
    public abstract class Unit
    {
        public string Name 
        { 
            get; set; 
        }

        public int Cost 
        { 
            get; set; 
        }

        public int HealthPoint 
        { 
            get; set; 
        }

        public int AttackPoint 
        { 
            get; set; 
        }

        public static int CompareByAttackPoints(Unit Unit1, Unit Unit2)
        {
            return Unit1.AttackPoint.CompareTo(Unit2.AttackPoint);
        }

    }

    // Militia.
    public class Militia : Unit
    {

        public Militia()
        {
            Name = "Militia";
            Cost = 10;
            HealthPoint = 4;
            AttackPoint = 2;
        }
    }

    // Footman.
    public class Footman : Unit
    {
        public Footman()
        {
            Name = "Footman";
            Cost = 25;
            HealthPoint = 8;
            AttackPoint = 4;
        }
    }

    // Knight.
    public class Knight : Unit
    {
        public Knight()
        {
            Name = "Knight";
            Cost = 50;
            HealthPoint = 22;
            AttackPoint = 7;
        }
    }


}
