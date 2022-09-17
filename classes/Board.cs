namespace MyApp{
    class Board{
        public static char[,] board = null!; // plateau 
        public static int[] SlotsStates(int x, int y)
        {
            int[] result = new int[2];
            if (board[x, y] == ' '){
                result[0] = x;
                result[1] = y;
            }else{
                if (board[x, y] == 'X')
                {
                    Console.WriteLine("Vous avez déjà joué ici..");
                    return Game.AskPlayer();
                }else
                {
                    Console.WriteLine("L'ordinateur a déjà joué ici..");
                    return Game.AskPlayer();
                }
            }
            return result;
        }

        public static bool isSlotsAvailable(int x, int y){
            if(board[x, y] == ' ')
            {
                return true;
            }else{
                return false;
            }
        }
        public static void RenderBoard(int a = 4, int b = 4){ // we put optional parameters that will be used to coloring the background of selected slot, here we put default value out of the board in order to do not color the background when we just want to show the board
            // string boardString = "";
            Console.Clear();
            Console.Out.NewLine = "";
            for(int i = 0; i < 3; i++){
                Console.WriteLine(($"     |     |{Environment.NewLine}"));
                for(int j = 0; j < 3; j++){
                    if(j < 2){
                        if(i == a && j == b){
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine($"  {board[i,j]}  ");
                            Console.ResetColor();
                        }else{
                            Console.WriteLine($"  {board[i,j]}  ");
                        }
                        Console.WriteLine("|");
                    }else{
                        if(i == a && j == b){
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine($"  {board[i,j]}  ");
                            Console.ResetColor();
                        }else{
                            Console.WriteLine($"  {board[i,j]}  ");
                        }
                    }
                }
                Console.WriteLine($"{Environment.NewLine}     |     |");
                if(i < 2){
                    Console.WriteLine($"{Environment.NewLine}-----+-----+-----{Environment.NewLine}");
                }
            }
            Console.Out.NewLine = Environment.NewLine;
        }
        public static bool CheckBoard(char symbol){
            int[][] slotToCheck = new int[4][]
            {
                new int[2]{0,0},
                new int[2]{1,0},
                new int[2]{2,0},
                new int[2]{2,1},
            };
            foreach(int[] value in slotToCheck){
                if(board[value[0], value[1]] == symbol){
                    switch (value[1]){
                        case 0: // si on est à la colonne 0
                            switch (value[0]){
                                case 0: // si on est à la ligne 0
                                    if(board[value[0]+1, value[1]] == symbol && board[value[0]+2, value[1]] == symbol){
                                        return true;
                                    }else if(board[value[0], value[1]+1] == symbol && board[value[0], value[1]+2] == symbol){
                                        return true;
                                    }else if(board[value[0]+1, value[1]+1] == symbol && board[value[0]+2, value[1]+2] == symbol){
                                        return true;
                                    }
                                    break;
                                    case 1: // si on est à la ligne 1
                                    if(board[value[0], value[1]+1] == symbol && board[value[0], value[1]+2] == symbol){
                                        return true;
                                    }
                                    break;
                                    case 2: // si on est à la ligne 2
                                    // diagonale bas gauche vers haut droite
                                    if(board[value[0]-1, value[1]+1] == symbol && board[value[0]-2, value[1]+2] == symbol){
                                        return true;
                                    }
                                    //ligne bas gauche vers bas droit
                                    if(board[value[0], value[1]+1] == symbol && board[value[0], value[1]+2] == symbol){
                                        return true;
                                    }
                                    break;
                                break;
                            }
                        break;
                        case 1: // si on est à la colonne 1
                            if(value[0] == 2){
                                if(board[value[0]-2, value[1]] == symbol && board[value[0]-1, value[1]] == symbol){
                                    return true;
                                }
                            }
                        break;
                        case 2: // si on est à la colonne 2
                            if(value[0] == 2){
                                if(board[value[0]-2, value[1]] == symbol && board[value[0]-1, value[1]] == symbol){
                                    return true;
                                }
                            }
                        break;
                    }
                }
            }
            return false;
        }
    }
}