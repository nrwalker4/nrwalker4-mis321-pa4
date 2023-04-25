using mis321_pa4;
Character character = new Character("player");

Menu menu = new Menu();
// menu.TitleScreen();
// menu.LoadingAnimation();
menu.OverviewText();

var game = menu.CharacterSelection();
// Console.WriteLine("Displaying Initial Stats: ");
game.DisplayStats();
while(game.CurrentAttacker.Character.Health > 0)
{
    Console.WriteLine();
    Console.Write($"Press key when {game.CurrentAttacker.Name} is finished");
    Console.ReadKey();

    //Switch the active player
    game.Attack();
    game.DisplayStats();
    game.SwitchPlayers();
}

     // DavyJones character1 = new DavyJones();
            // JackSparrow character2 = new JackSparrow();

            // int health1 = character1.Health;
            // int health2 = character2.Health;

            // double bonus1 = 0;
            // double bonus2 = 0;
            // bonus1 = 1;
            // while(health1 > 0 && health2 > 0)
            // {
            //     if(nextToPlay == 1)
            //     {
                
            //         character1.Attack(bonus1);
            //         nextToPlay = 2;

            //     }
            //     else
            //     {
            //         character1.Attack(bonus2);
            //         nextToPlay = 1;
            //     }
                   
            // }