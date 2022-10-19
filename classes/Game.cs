namespace MyApp
{
    class Game
    {
        public static bool playerTurn = true;
        public static bool quitGame = false;
        public static int gameMode = 0;

        public static void LaunchGame()
        {
            Board.board = new char[3, 3]
            {
                { ' ', ' ', ' '},
                { ' ', ' ', ' '},
                { ' ', ' ', ' '},
            };
            while (!quitGame)
            {
                do
                {
                    Console.WriteLine("1 : Local 2 players" + Environment.NewLine + "2 : Playing against computer");
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            gameMode = 1;
                            break;
                        case ConsoleKey.D2:
                            gameMode = 2;
                            break;
                        default:
                            gameMode = 0;
                            break;
                    }
                }while (gameMode == 0);

                if (gameMode == 1){
                    VersusPlayer();
                }else{
                    VersusComputer();
                }
            }
            if (!quitGame)
            {
                Console.WriteLine("Appuyer sur [escape] pour quitter");

            GetKey:
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        quitGame = true;
                        // Console.Clear();
                        break;
                    default:
                        goto GetKey
                    ;
                }
            }
        }

        public static void VersusComputer(){
            if (!Board.CheckBoard('X') && !Board.CheckBoard('Y'))
                {
                    if (playerTurn)
                    {
                        int[] aa = new int[] { 0, 1 };
                        PlayerTurn();
                    }
                    else
                    {
                        ComputerTurn();
                    }
                }
                else
                {
                    if (Board.CheckBoard('X'))
                    {
                        Console.WriteLine("Joueur a gagné");
                    }
                    else
                    {
                        Console.WriteLine("Ordinateur a gagné");
                    }
                    quitGame = true;
                }
        }
        public static void VersusPlayer(){

        }
        public static void PlayerTurn()
        {
            Board.RenderBoard();
            int[] currentTurn = AskPlayer();
            int x = currentTurn[0];
            int y = currentTurn[1];
            Board.board[x, y] = 'X';
            Board.RenderBoard();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Cliquez sur une touche pour continuer");
            Console.ReadKey();

            playerTurn = false;
        }
        public static int[] AskPlayer()
        {
            int y = 0;
            int x = 0;
            do
            {
                Console.WriteLine("Appuyer sur [entrer] pour valider");
            GetKey:
                Console.WriteLine("x: " + x + " y: " + y);
                Board.RenderBoard(y, x);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        y--;
                        goto GetKey;
                    case ConsoleKey.DownArrow:
                        y++;
                        goto GetKey;
                    case ConsoleKey.LeftArrow:
                        x--;
                        goto GetKey;
                    case ConsoleKey.RightArrow:
                        x++;
                        goto GetKey;
                    case ConsoleKey.Enter:
                        // Console.Clear();
                        break;
                    case ConsoleKey.Escape:
                        quitGame = true;
                        break;
                    default:
                        goto GetKey
                    ;
                }
            } while (!Board.isSlotsAvailable(y, x));

            return Board.SlotsStates(y, x);
        }

        public static void ComputerTurn()
        {
            Random aleatoire = new Random();
            int x;
            int y;
            do
            {
                x = aleatoire.Next(3);
                y = aleatoire.Next(3);
            } while (!Board.isSlotsAvailable(x, y));


            Board.board[x, y] = 'O';
            Console.WriteLine("L'ordinateur a joué");
            playerTurn = true;
        }
    }
}