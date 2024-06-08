
namespace ConsoleApp31
{
    internal class Game
    {
        public char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        public char another;
        public bool bot;
        public void Start()
        {
            Random rand = new Random();
            another = rand.Next(0, 2) == 0 ? 'X' : 'O';
            Console.Write("Bot?: ");
            bot = Console.ReadLine().ToLower() == "Yeah";
            while (true)
            {
                Console.Clear();
                PrintBoard();
                if (CheckWin())
                {
                    Console.WriteLine($"Player {another} win!");
                    break;
                }
                if (CheckDraw())
                {
                    Console.WriteLine("Draw!");
                    break;
                }
                Console.WriteLine($"Player {another}");
                if (another == 'X' || !bot)
                {
                    PlayerMove();
                }
                else
                {
                    ComputerMove();
                }
                another = another == 'X' ? 'O' : 'X';
            }
        }
        public void PrintBoard()
        {
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        }
        public void PlayerMove()
        {
            int move;
            do
            {
                Console.Write("Input 1-9: ");
            } while (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 9 || board[move - 1] != ' ');

            board[move - 1] = another;
        }
        public void ComputerMove()
        {
            Random rand = new Random();
            int move;
            do
            {
                move = rand.Next(0, 9);
            } while (board[move] != ' ');

            board[move] = 'O';
        }
        public bool CheckWin()
        {
            int[,] winConditions = {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8},
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8},
                {0, 4, 8}, {2, 4, 6}
            };
            for (int i = 0; i < winConditions.GetLength(0); i++)
            {
                if (board[winConditions[i, 0]] == another &&
                    board[winConditions[i, 1]] == another &&
                    board[winConditions[i, 2]] == another)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckDraw()
        {
            foreach (char spot in board)
            {
                if (spot == ' ')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
