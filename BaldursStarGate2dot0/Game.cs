namespace BaldursStarGate2dot0
{
    internal class Game
    {
        //TODO GUI Life / level / mana
        //TODO Counter Battles won
        //TODO XP & Level
        //TODO Cleanup (refactoring)
        //TODO Choose weapons
        //TODO Save in files
        //TODO Register player
        //TODO Exceptions

        public const int Dice = 20;
        public static Random Rnd = new Random();

        public Game()
        {
            Player pg = CreatePlayer();
            while (GameMenu(pg)) ;
        }

        public Game(Player player)
        {
            while (GameMenu(player)) ;
        }

        bool GameMenu(Player player)
        {
            Console.Clear();
            Gui.ShowPlayer(player);
            Gui.Print(10, 8, "*** Game Menu ***");
            Gui.Print(10, 9, "[1] Open Stargate");
            Gui.Print(10, 10, "[2] Go shopping");
            Gui.Print(10, 11, "[3] Rest & Relax");
            Gui.Print(10, 12, "[4] Return to main menu");
            Gui.Print(10, 13, "[5] Save game");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    Monster monster = CreateMonster();
                    //new Battle(player, monster);
                    bool result = new Battle().Combat(player, monster);
                    if (result) Gui.Print(20, 10, "Player won");
                    else Gui.Print(20, 10, "Monster won");
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    //TODO Create a shop
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    player.Health += 10;
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    return false;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    Io.Save(player);
                    break;
                default:
                    break;
            }
            return true;
        }

        private Player CreatePlayer()
        {
            Player pcp = new Player();
            pcp.MaxHealth = 100;
            pcp.Health = pcp.MaxHealth;
            pcp.Armor = 2;
            pcp.Type = "Player";
            Gui.Print(3, 5, "Name: ");
            pcp.Name = Console.ReadLine();
            return pcp;
        }

        private Monster CreateMonster()
        {
            return new Monster();
        }
    }
}