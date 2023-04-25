using mis321_pa4.Interfaces;
namespace mis321_pa4
{
    public class Game : IAttack
    {
        public Player Player1 {get;set;} = new Player(string.Empty);
        public Player Player2 {get;set;} = new Player(string.Empty);

        public Player CurrentAttacker{get;set;} = new Player(string.Empty);
        public Player CurrentDefender{get;set;} = new Player(string.Empty);

        public Game(Player player1, Player player2, Player startingAttacker, Player startingDefender)
        {
            Player1 = player1;
            Player2 = player2;
            CurrentAttacker = startingAttacker;
            CurrentDefender = startingDefender;
        }
        
        public void Attack()
        {
            if(CurrentAttacker.Character == null || CurrentDefender.Character == null)
            {
                throw new ApplicationException("Character cannot be null");
            }
            Console.WriteLine($"{CurrentAttacker.Character.Name} is attacking {CurrentDefender.Character.Name}");
            double bonusMultiplier = 1.0;
            if(
                (CurrentAttacker.Character is JackSparrow && CurrentDefender.Character is WillTurner) || 
                (CurrentAttacker.Character is WillTurner && CurrentDefender.Character is DavyJones) ||
                (CurrentAttacker.Character is DavyJones && CurrentDefender.Character is JackSparrow) )
            {
                bonusMultiplier = 1.2;
            }
            Double damageDelt = (CurrentAttacker.Character.AttackStrengh - CurrentDefender.Character.DefensivePower) * bonusMultiplier;
            if(damageDelt < 0)
            {
                //Require damage delt to be >= 0, otherwise defenders defensives power can increase after being attacked
                damageDelt = 0;
            }
            CurrentDefender.Character.Health = CurrentDefender.Character.Health - damageDelt;
            Console.WriteLine($"{CurrentDefender.Character.Name}'s Health is now {CurrentDefender.Character.Health}");
        }

        public void SwitchPlayers()
        {
            if(CurrentAttacker == Player1)
            {
                CurrentAttacker = Player2;
                CurrentDefender = Player1;
            }
            else
            {
                CurrentAttacker = Player1;
                CurrentDefender = Player2;
            }
            Console.WriteLine();
            Console.WriteLine($"Switch to Attacker {CurrentAttacker.Name}");
        }

        public void DisplayStats()
        {
            if(CurrentAttacker.Character == null || CurrentDefender.Character == null)
            {
                 throw new ApplicationException("Character cannot be null");
            }
            Console.WriteLine("CURRENT STATS:\n");

            Console.WriteLine($"{CurrentDefender.Character.Name}: Health: {CurrentDefender.Character.Health}, AttackStrength: {CurrentDefender.Character.AttackStrengh}, DefensivePower: {CurrentDefender.Character.DefensivePower}, MaxPower: {CurrentDefender.Character.MaxPower}");
            Console.WriteLine($"{CurrentAttacker.Character.Name}: Health: {CurrentAttacker.Character.Health}, AttackStrength: {CurrentAttacker.Character.AttackStrengh}, DefensivePower: {CurrentAttacker.Character.DefensivePower}, MaxPower: {CurrentAttacker.Character.MaxPower}");
        }
    }
}