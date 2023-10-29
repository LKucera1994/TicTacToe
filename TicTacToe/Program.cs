namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=string.Empty ;
            
            bool isPlayerOneActive = false;

            int result;

            bool reset=false;

            int i = 0;

            string[,] matrix =
            {
                {"1","2","3"},
                {"4","5","6"},
                {"7","8","9"}
            };


            while(true)
            {
                


                Console.WriteLine($"     |     |  ");
                Console.WriteLine($"  {matrix[0, 0]}  |  {matrix[0, 1]}  |  {matrix[0, 2]}");
                Console.WriteLine($"_____|_____|_____");
                Console.WriteLine($"     |     |  ");
                Console.WriteLine($"  {matrix[1, 0]}  |  {matrix[1, 1]}  |  {matrix[1, 2]}");
                Console.WriteLine($"_____|_____|_____");
                Console.WriteLine($"     |     |  ");
                Console.WriteLine($"  {matrix[2, 0]}  |  {matrix[2, 1]}  |  {matrix[2, 2]}");
                Console.WriteLine($"     |     |  ");

                if (CheckWinCondition(matrix))
                {
                    if (isPlayerOneActive)
                    {
                        Console.WriteLine("Player 1 has won!");

                    }
                    else
                    {
                        Console.WriteLine("Player 2 has won!");
                    }

                    Console.WriteLine("Enter any number to restart the game.");

                    while (true)
                    {
                        input = Console.ReadLine();


                        if (input == null || !int.TryParse(input, out result))
                        {
                            Console.WriteLine("Enter any number to restart the game.");
                            continue;
                        }


                        else
                        {
                            ResetMatrix(matrix);
                            reset = true;
                            break;
                            
                        }


                    }

                }
                if(reset) //skip the rest of the loop if player wants to reset the game
                {
                    reset = !reset;
                    Console.Clear();
                    continue;
                }





                //toggle between Player One and Player Two. If isPlayerOneActive is false, it means that it is Player two´s turn.
                isPlayerOneActive = !isPlayerOneActive;




                if (isPlayerOneActive)
                {
                    Console.WriteLine("Player 1: Choose your field!");

                }
                else
                {
                    Console.WriteLine("Player 2: Choose your field!");


                }

                while (true) // Read input
                {
                    input = Console.ReadLine();

                    
                    if (input == null || !int.TryParse(input,out result))
                    {
                        Console.WriteLine("Enter a Number");
                        continue;
                    }

                    if (CheckField(matrix, input))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That Field is already taken or not valid!");
                    }


                }

     
                switch (input)//assign input to matrix
                {
                    case "1" : matrix[0, 0] = (isPlayerOneActive) ? "X" : "O"; break;
                    case "2" : matrix[0, 1] = (isPlayerOneActive) ? "X" : "O"; break;
                    case "3" : matrix[0, 2] = (isPlayerOneActive) ? "X" : "O"; break;
                    case "4" : matrix[1, 0] = (isPlayerOneActive) ? "X" : "O"; break;
                    case "5" : matrix[1, 1] = (isPlayerOneActive) ? "X" : "O"; break;
                    case "6" : matrix[1, 2] = (isPlayerOneActive) ? "X" : "O"; break;
                    case "7" : matrix[2, 0] = (isPlayerOneActive) ? "X" : "O"; break;
                    case "8" : matrix[2, 1] = (isPlayerOneActive) ? "X" : "O"; break;
                    case "9" : matrix[2, 2] = (isPlayerOneActive) ? "X" : "O"; break;
                    default :
                        Console.WriteLine("Invalid Input!");
                        continue;                 
                }

                //if no one wins: restart the game
                i++;
                if (i == 9)
                {
                    i = 0;
                    Console.WriteLine("Game Over: No player wins.");
                    Console.WriteLine("Enter any number to restart the game.");
                    input = Console.ReadLine();

                    if (input != null)
                    {
                        ResetMatrix(matrix);
                    }

                }
               
                Console.Clear();
    
            }

        }


        static bool CheckField(string[,] board,string input) //Check if the field is already taken or valid
        {
            switch (input)
            {
                case "1":
                    if (board[0, 0] == "1")
                        return true;
                    else
                        return false;

                case "2":
                    if (board[0, 1] == "2")
                        return true;
                    else
                        return false;
                case "3":
                    if (board[0, 2] == "3")
                        return true;
                    else
                        return false;
                case "4":
                    if (board[1, 0] == "4")
                        return true;
                    else
                        return false;
                case "5":
                    if (board[1, 1] == "5")
                        return true;
                    else
                        return false;
                case "6":
                    if (board[1, 2] == "6")
                        return true;
                    else
                        return false;
                case "7":
                    if (board[2, 0] == "7")
                        return true;
                    else
                        return false;
                case "8":
                    if (board[2, 1] == "8")
                        return true;
                    else
                        return false;
                case "9":
                    if (board[2, 2] == "9")
                        return true;
                    else
                        return false;

                default:
                   
                    return false;


            }

        }


        static void ResetMatrix(string[,] board)
        {
            int k = 1;
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = k.ToString();
                    k++;

                }
            }
          
        }

        public static bool CheckWinCondition(string[,] board)
        {
            string checkingVariable = string.Empty;
            //Horizontal  
            //is there a symbol ("X" or "O") in the middle column? if yes: assign that to checkingVariable 
            //return true if the symbol left and right of the checkingVariable are the same as checkingVariable

            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, 1] == "X" || board[i, 1] == "O") 
                {
                    checkingVariable = board[i, 1]; 

                    if (board[i, 0] == checkingVariable && board[i, 2] == checkingVariable)  
                    {                                                                         
                        return true;
                    }


                }

            }

            //Vertical
            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (board[1, i] == "X" || board[1, i] == "O")
                {
                    checkingVariable = board[1, i];

                    if (board[0, i] == checkingVariable && board[2, i] == checkingVariable)
                    {
                        return true;
                    }


                }

            }

            //Diagonal 

            if (board[1, 1] == "X" || board[1, 1] == "O")
            {
                checkingVariable = board[1, 1];

                if (board[0, 0] == checkingVariable && board[2, 2] == checkingVariable)
                {
                    return true;
                }

                if (board[2, 0] == checkingVariable && board[0, 2] == checkingVariable)
                {
                    return true;
                }



            }

            return false;
        }

    }
}
