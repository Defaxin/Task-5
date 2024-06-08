

namespace ConsoleApp31
{
    internal class Translation
    {
        public static readonly Dictionary<char, string> toMorse = new Dictionary<char, string>()
        {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
            {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
            {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
            {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
            {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
            {'Z', "--.."}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
            {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."},
            {'9', "----."}, {' ', "/"}
        };
        public static readonly Dictionary<string, char> fromMorse = new Dictionary<string, char>();
        static Translation()
        {
            foreach (var pair in toMorse)
            {
                fromMorse[pair.Value] = pair.Key;
            }
        }
        public static string ToMorse(string input)
        {
            string result = "";
            foreach (char c in input.ToUpper())
            {
                if (toMorse.ContainsKey(c))
                {
                    result += toMorse[c] + " ";
                }
            }
            return result.Trim();
        }
        public static string FromMorse(string input)
        {
            string[] morseWords = input.Split('/');
            string result = "";

            foreach (string morseWord in morseWords)
            {
                string[] morseChars = morseWord.Trim().Split(' ');

                foreach (string morseChar in morseChars)
                {
                    if (fromMorse.ContainsKey(morseChar))
                    {
                        result += fromMorse[morseChar];
                    }
                }
                result += " ";
            }
            return result.Trim();
        }
    }
}
