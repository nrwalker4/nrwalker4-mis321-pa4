namespace mis321_pa4
{
    public class Player
    {
        public string Name {get;set;}
        
        public Character? Character {get;set;}

        public Player(string name)
        {
            Name = name;
        }

        public void SetCharacter(Character character)
        {
            Character = character;
        }
    }
}