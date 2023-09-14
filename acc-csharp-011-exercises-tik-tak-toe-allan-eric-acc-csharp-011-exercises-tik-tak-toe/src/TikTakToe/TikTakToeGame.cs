namespace TikTakToe;
//ok
public class TikTakToeGame
{
    public char[,] board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
    public char currentPlayer = 'x';
    public char winner = ' ';


  public void printBoard()
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            string line = "";
            char space = ' ';
            for (int j = 0; j < board.GetLength(1); j++)
            {
                line += board[i, j] + space.ToString();
            }
            Console.WriteLine(line);
        }
    }

    public void makeMove(int line, int column, char player)
    {
        if (board[line, column] == ' ')
        {
            board[line, column] = player;
        }
        else
        {
            Console.WriteLine("Jogada inválida!");
        }

    }

    public bool isGameOver()
    {
       bool isGameOver = false;
       for (int i = 0; i < board.GetLength(0); i++)
       {
           if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != ' ')
           {
               isGameOver = true;
               winner = board[i, 0];
           }
           else if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != ' ')
           {
               isGameOver = true;
               winner = board[0, i];
           }
       }
       return isGameOver;
    }

    public void printResults()
    {
        if (winner == ' ')
        {
            Console.WriteLine("Empate! Deu Velha!");
        }
        else
        {
            Console.WriteLine("O jogador " + winner + " venceu!");
        }
    }

    public char getCurrentPlayer()
    {
        return currentPlayer;
    }

    public int[] getPlayerEntry()
    {
        Console.WriteLine("Jogador " + currentPlayer + " informe a linha:");
        string input = Console.ReadLine() ?? "";
        int line = int.Parse(input);

        Console.WriteLine("Jogador " + currentPlayer + " informe a coluna:");
        input = Console.ReadLine() ?? "";
        int column = int.Parse(input);

        return new int[] { line, column };
    }

    public void changePlayer()
    {
        if(currentPlayer == 'x')
        {
            currentPlayer = 'o';
        }
        else
        {
            currentPlayer = 'x';
        }
    }
}   
