namespace MyApp{
    
    class Game{
        public static bool playerTurn = true;
        public static bool quitGame = false;
        
        public static void LaunchGame(){
            Board.board = new char[3 ,3]
            {
                { ' ', ' ', ' '},
                { ' ', ' ', ' '},
                { ' ', ' ', ' '},
            };
            while(!quitGame)
            {
                if(!Board.CheckBoard('X') && !Board.CheckBoard('Y')){
                    if(playerTurn){
                        int[] aa = new int[] {0, 1};
                        PlayerTurn();
                    }else{
                        ComputerTurn();
                    }
                }else{
                    if(Board.CheckBoard('X')){
                        Console.WriteLine("Joueur a gagné");
                    }else{
                        Console.WriteLine("Ordinateur a gagné");
                    }
                    quitGame = true;
                }
            }
            if(!quitGame)
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
        public static void PlayerTurn()
        {
            Board.RenderBoard();
            int[] currentTurn = AskPlayer();
            int x = currentTurn[0];
            int y = currentTurn[1];
            Board.board[x-1, y-1] = 'X';
            Board.RenderBoard();
            Console.WriteLine("Cliquez sur une touche pour continuer");
            Console.ReadKey();

            playerTurn = false;
        }
        public static int[] AskPlayer(){
            int x;
            int y;
            int[] result = new int[2];

            do{
                Console.WriteLine("Dans quelle ligne souhaitez vous jouer ?");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Dans quelle colonne souhaitez vous jouer ?");
                y = Convert.ToInt32(Console.ReadLine());
            }while(x > 3 || x <= 0 || y > 3 || y <= 0); // si les coordonnées souhaité ne sont pas valides

            return Board.SlotsStates(x, y);
        }

        public static void ComputerTurn()
        {
            Random aleatoire = new Random();
            int x;
            int y;
            do{
                x = aleatoire.Next(3);
                y = aleatoire.Next(3);
            }while(!Board.isSlotsAvailable(x, y));
            
            
            Board.board [x, y] = 'O';
            Console.WriteLine("L'ordinateur a joué");
            playerTurn = true;
        }
    }
}