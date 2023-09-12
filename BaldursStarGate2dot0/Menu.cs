namespace BaldursStarGate2dot0
{
    internal class Menu
    {
        public Menu()
        {
            while (true) StartMenu();
        }

        private void StartMenu()
        {
            Console.Clear();
            Gui.Print(10, 8, "*** Menu ***");
            Gui.Print(10, 9, "[1] New Game");
            Gui.Print(10, 10, "[2] Load Game");
            Gui.Print(10, 11, "[3] Exit Game");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    new Game();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Player? player = Io.Load<Player>();
                    if (player == null)
                    {
                        Gui.Print(7, 10, "Failed to load game!", ConsoleColor.Red);
                        Console.ReadKey();
                    }
                    else new Game(player);
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}
