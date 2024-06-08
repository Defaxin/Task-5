namespace ConsoleApp31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();

            Console.Write("Input text: ");
            string input = Console.ReadLine();
            string morseCode = Translation.ToMorse(input);
            Console.WriteLine($"Translet to: {morseCode}");

            Console.Write("Input text: ");
            string morseInput = Console.ReadLine();
            string normalText = Translation.FromMorse(morseInput);
            Console.WriteLine($"Translet: {normalText}");
        }
    }
}
