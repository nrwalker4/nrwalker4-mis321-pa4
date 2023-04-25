using mis321_pa4.Interfaces;
namespace mis321_pa4
{
    public class Menu 
    {
        public void TitleScreen()
        {
            Console.ResetColor();
           
            Console.ForegroundColor = ConsoleColor.White;  //A small extra used to
        
            System.Console.WriteLine(@"
            
             ██████╗ █████╗ ██╗  ██╗   ██╗██████╗  ██████╗ ███████╗                                             
            ██╔════╝██╔══██╗██║  ╚██╗ ██╔╝██╔══██╗██╔═══██╗██╔════╝                                             
            ██║     ███████║██║   ╚████╔╝ ██████╔╝██║   ██║███████╗                                             
            ██║     ██╔══██║██║    ╚██╔╝  ██╔═══╝ ██║   ██║╚════██║                                             
            ╚██████╗██║  ██║███████╗██║   ██║     ╚██████╔╝███████║                                             
             ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝   ╚═╝      ╚═════╝ ╚══════╝ ");  
   
            System.Console.WriteLine(@"                        
                                    ███╗   ███╗ █████╗ ██╗     ███████╗███████╗████████╗ ██████╗ ██████╗ ███╗   ███╗
                                    ████╗ ████║██╔══██╗██║     ██╔════╝██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗████╗ ████║
                                    ██╔████╔██║███████║██║     █████╗  ███████╗   ██║   ██║   ██║██████╔╝██╔████╔██║
                                    ██║╚██╔╝██║██╔══██║██║     ██╔══╝  ╚════██║   ██║   ██║   ██║██╔══██╗██║╚██╔╝██║
                                    ██║ ╚═╝ ██║██║  ██║███████╗███████╗███████║   ██║   ╚██████╔╝██║  ██║██║ ╚═╝ ██║
                                    ╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝");
     
            System.Console.WriteLine("Press any key to continue");

            Console.ReadKey();
            Console.Clear();
        }

        public void LoadingAnimation()     
        {
            for(int i =0; i <= 100; i++)
            {
                Console.Write($"\rLoading:  {i}% ");
                Thread.Sleep(15);
            }
            Console.Clear();
            System.Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        public void OverviewText()
        {
            string overViewText = "Welcome to the Battle of Caylpso's Malestorm!\nThis is a two player console game where each player takes a turn at attacking and defending!";
            Text.TextFlow();
            Text.WriteStaggeredText(overViewText, 1, 25, ConsoleColor.DarkRed);

            overViewText = "Each game/round has randomized stats.\nYou will alternate attacks until a characters health reaches 0.";
            Text.TextFlow();
            Text.WriteStaggeredText(overViewText, 1, 25, ConsoleColor.DarkRed);

            Console.ResetColor();
        }

        public Game CharacterSelection()
        {
            // JackSparrow character1 = new JackSparrow();
            // WillTurner character2 = new WillTurner();
            // DavyJones charcter3 = new DavyJones();
            Console.WriteLine();
            Console.WriteLine();
            var player1Name = string.Empty;
            while(string.IsNullOrEmpty(player1Name))
            {
                Console.Write("Player 1 enter your name: ");
                player1Name = Console.ReadLine();
            }

            var player1CharacterName = string.Empty;
            while(string.IsNullOrEmpty(player1CharacterName))
            {
                Console.WriteLine($"{player1CharacterName}\n choose your character:\n D = Davy Jones \n J = Jack Sparrow\n W = Will Turner");
                player1CharacterName = Console.ReadLine();
            }

            var player2Name = string.Empty;
            while(string.IsNullOrEmpty(player2Name))
            {
                Console.Write("Player 2 enter your name: ");
                player2Name = Console.ReadLine();
            }

            var player2CharacterName = string.Empty;
            while(string.IsNullOrEmpty(player2CharacterName))
            {
               Console.WriteLine($"{player2CharacterName}\n choose your character:\n D = Davy Jones \n J = Jack Sparrow\n W = Will Turner");
                player2CharacterName = Console.ReadLine();
            } 

            
            var player1 = new Player(player1Name);
            if(player1CharacterName == "D")
            {
                player1.Character = new DavyJones();
            }
            else if(player1CharacterName == "J")
            {
                player1.Character = new JackSparrow();
            }
            else if(player1CharacterName == "W")
            {
                player1.Character = new WillTurner();
            }

            var player2 = new Player(player2Name);
            if(player2CharacterName == "D")
            {
                player2.Character = new DavyJones();
            }
            else if(player2CharacterName == "J")
            {
                player2.Character = new JackSparrow();
            }
            else if(player2CharacterName == "W")
            {
                player2.Character = new WillTurner();
            }

            Console.WriteLine("Characters have been chosen!");
            
            // if(player1 == character1 || character2 )

            var startingAttackerPlayerNumber = GetStartingPlayerNumber();
            
            Player startingAttacker = startingAttackerPlayerNumber == 1 ? player1 : player2;
            Console.WriteLine($"\nStarting attacker is {startingAttacker.Name}"); 

            Player startingDefender = startingAttackerPlayerNumber == 1 ? player2 : player1;
            Console.WriteLine($"\nStarting defender is {startingDefender.Name}"); 

            return new Game(player1, player2, startingAttacker, startingDefender);
        }

        private int GetStartingPlayerNumber()
        {
            int startingPlayerNumber = 0;
            Random number = new Random();
            int num = number.Next(1, 3);
            if(num < 3)
            {
                startingPlayerNumber = 1;
            }
            else
            {
                startingPlayerNumber = 2;
            }
            return startingPlayerNumber;
        }
    }
}