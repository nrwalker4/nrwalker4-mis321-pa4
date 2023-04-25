using mis321_pa4.Interfaces;

namespace mis321_pa4
{
    public class Character
    {
        public string Name { get; set; }
        public double Health { get; set;}

        public int MaxPower { get; set; }
        public double  AttackStrengh { get; set; }
        public double DefensivePower { get; set; }

        public Character(string name)
        {
            Name = name;
            Health = 100;

            Random rand = new Random();
            MaxPower = rand.Next(1, 101);
            AttackStrengh = rand.Next(1, MaxPower);
            DefensivePower = rand.Next(1, MaxPower);
        }
    }
}